using Application.Exceptions;
using Application.Services.JwtUtils;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.Extensions.Options;
using Shared;
using Infrastructure.Entities.Token;
using System.Security.Cryptography;
using Infrastructure.Entities.UserRepo;
using AutoMapper;
using Application.Services.Mail;
using Infrastructure.Entities.UserBalance;
using Infrastructure.Entities.ConfirmationMailToSend;
using System.Security.Policy;

namespace Application.Services.AuthenticationManagment
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly BaseUrl _baseUrl;
        private readonly IJwtUtilsService _jwtUtils;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;
        private readonly IUserBalanceRepository _userBalanceRepository;
        private readonly IConfirmationMailToSendRepository _confirmationMailToSendRepository;
        private readonly IMapper _mapper;
        public AuthenticationService(BaseUrl baseUrl,
            IOptions<JwtSettings> options, 
            IUserRepository userRepository,
            IJwtUtilsService jwtUtils,
            IUnitOfWork unitOfWork,
            IMailService mailService,
            IUserBalanceRepository userBalanceRepository,
            IConfirmationMailToSendRepository confirmationMailToSendRepository,
            IMapper mapper)
        {
            _baseUrl = baseUrl;
            _userRepository = userRepository;
            _jwtSettings = options.Value;
            _jwtUtils = jwtUtils;
            _unitOfWork = unitOfWork;
            _mapper = mapper;     
            _userBalanceRepository = userBalanceRepository;
            _mailService = mailService;
            _confirmationMailToSendRepository = confirmationMailToSendRepository;
         }
        public async Task<AuthenticateResponse> Authenticate(LoginDto model, string ipAddress)
        {

            var user = await _userRepository.GetUserAndToken(model);
            // validate
            if
            (user == null ||
                (
                    await PasswordEncryptor.EncryptPassword(model.Password, Convert.FromBase64String(user.Salt))!= user.Password
                )
            )
            {
               throw new CustomException("Username or password is incorrect", 400);
            }
               
            if (!user.IsVerified)
            {
                throw new CustomException("Username not verified",400);
            }


            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken =await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            await RemoveOldRefreshTokens(user);

            // save changes to db
            //_userRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return new AuthenticateResponse(user, jwtToken, user.Role, refreshToken.Token);
        }

        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var user = await GetUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                await RevokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                await _unitOfWork.CompleteAsync();
            }

            if (!refreshToken.IsActive)
                throw new CustomException("Invalid token", 400);

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = await RotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            RemoveOldRefreshTokens(user);

            // save changes to db
            await _unitOfWork.CompleteAsync();

            // generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, user.Role, newRefreshToken.Token);
        }

        public async Task<bool> RevokeToken(string token, string ipAddress)
        {
            var user = await GetUserByRefreshToken(token);

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            await _unitOfWork.CompleteAsync();
            if (!refreshToken.IsActive)
            {
                throw new CustomException("Invalid token", 400);
            }

            // revoke token and save
            RevokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<UserEntity> GetById(int id)
        {
            var user = await _userRepository.FindByConditionAsync(x => x.Id == id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        // helper methods

        private async Task<UserEntity> GetUserByRefreshToken(string token)
        {
            var user = await _userRepository.GetUserByToken(token);

            if (user == null)
                throw new CustomException("Invalid token", 400);

            return user;
        }

        private async Task<RefreshToken> RotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken =await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
            RevokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private async Task RemoveOldRefreshTokens(UserEntity user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_jwtSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, UserEntity user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    RevokeRefreshToken(childToken, ipAddress, reason);
                else
                    RevokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private Task RevokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
            return null;
        }

        public async Task<bool> RegisterUser(RegistrerDto model)
        {
            // validate
            var user = await _userRepository.FindByConditionAsync(x => x.UserName == model.Username);
            if (user != null)
            {
                throw new CustomException("user already exists", 400);
            }
            var mail = await _userRepository.FindByConditionAsync(x => x.Email == model.Email);
            if (mail != null)
            {
                throw new CustomException("email already exists", 400);
            }

            // map model to new account object
            var account = _mapper.Map<UserEntity>(model);

            var isFirstAccount = (await _userRepository.GetAllAsync()).Count() == 0;
            account.Role = Roles.NormalUser;
            account.DateCreated = DateTime.UtcNow;
            account.VerificationToken = await generateVerificationToken();
  
            // hash password
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            account.Password = await PasswordEncryptor.EncryptPassword(model.Password, salt);
            account.Salt = Convert.ToBase64String(salt);


            await _userRepository.CreateAsync(account);
            await _unitOfWork.CompleteAsync();
            var ConfirmationLink = _baseUrl.applicationUrl + @"/api/Auth/VerifyEmail/" + account.VerificationToken;
            //new Uri(@"/api/Auth/VerifyEmail/"+account.VerificationToken,UriKind.RelativeOrAbsolute);
            var mailToSend = new ConfirmationMailToSendEntity
            {
                UserId=account.Id,
                Email=account.Email,
                ConfirmationLink=ConfirmationLink,
                DateCreated=DateTime.Now,
                UserName=account.UserName,
            };
            await _confirmationMailToSendRepository.CreateAsync(mailToSend);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        private async Task<string> generateVerificationToken()
        {
            // token is a cryptographically strong random sequence of values
            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            // ensure token is unique by checking against db
            var tokenIsUnique = (await _userRepository.FindByConditionAsync(x => x.VerificationToken == token) == null);
            if (!tokenIsUnique)
                return await generateVerificationToken();

            return token;
        }

        public async Task<bool> VerifyEmail(string token)
        {
            var account = await _userRepository.FindByConditionAsync(x => x.VerificationToken == token);
            if (account == null)
                throw new CustomException("Verification failed", 400);
            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;
            

            var userBalance = new UserBalanceEntity
            {
                UserId=account.Id,
                balance=0,
                DateCreated=DateTime.Now,
            };
            await _userBalanceRepository.CreateAsync(userBalance);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> SendNewPassword(string mail)
        {
            var user = await _userRepository.FindByConditionAsync(x => x.Email == mail);
            Random random = new();
            var length = random.Next(12, 20);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var newPass=new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            user.Password = await PasswordEncryptor.EncryptPassword(newPass.ToString(), salt);
            user.Salt = Convert.ToBase64String(salt);
            await _mailService.SendNewPassword(new UserSendNewPasswordDto {UserName=user.UserName,Password=newPass,Email=user.Email });
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> ChangePassword(NewPasswordDto model,int userId)
        {
            var user = await _userRepository.FindByConditionAsync(x => x.Id==userId);
            if (user == null)
            {
                throw new CustomException("this user does not exist", 400);
            }
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            user.Password = await PasswordEncryptor.EncryptPassword(model.newPassword, salt);
            user.Salt = Convert.ToBase64String(salt);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}

