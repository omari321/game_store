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

namespace Application.Services.AuthenticationManagment
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly IJwtUtilsService _jwtUtils;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthenticationService(IOptions<JwtSettings> options, IUserRepository userRepository,
            IJwtUtilsService jwtUtils,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtSettings = options.Value;
            _jwtUtils = jwtUtils;
            _unitOfWork = unitOfWork;
            _mapper = mapper;     
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
                throw new CustomException("Username or password is incorrect", 400);
            //if (!user.IsVerified)
            //{
            //    throw new AppException("Username not verified");
            //}


            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken =await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            await removeOldRefreshTokens(user);

            // save changes to db
            //_userRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return new AuthenticateResponse(user, jwtToken, user.Role, refreshToken.Token);
        }

        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var user = await getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                await revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                //await _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }

            if (!refreshToken.IsActive)
                throw new CustomException("Invalid token", 400);

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = await rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            //_userRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            // generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, user.Role, newRefreshToken.Token);
        }

        public async Task<bool> RevokeToken(string token, string ipAddress)
        {
            var user = await getUserByRefreshToken(token);

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            await _unitOfWork.CompleteAsync();
            if (!refreshToken.IsActive)
            {
                throw new CustomException("Invalid token", 400);
            }

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            //_userRepository.Update(user);
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

        private async Task<UserEntity> getUserByRefreshToken(string token)
        {
            var user = await _userRepository.GetUserByToken(token);

            if (user == null)
                throw new CustomException("Invalid token", 400);

            return user;
        }

        private async Task<RefreshToken> rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken =await _jwtUtils.GenerateRefreshTokenAsync(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private async Task removeOldRefreshTokens(UserEntity user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_jwtSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private async Task revokeDescendantRefreshTokens(RefreshToken refreshToken, UserEntity user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private Task revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
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
            var user = await _userRepository.FindByConditionAsync(x => x.UserName == model.Username && x.Email == model.Email);
            if (user != null)
            {
                throw new CustomException("account already exists", 400);
            }

            // map model to new account object
            var account = _mapper.Map<UserEntity>(model);

            // first registered account is an admin
            var isFirstAccount = (await _userRepository.GetAllAsync()).Count() == 0;
            account.Role = Roles.NormalUser;
            account.DateCreated = DateTime.UtcNow;
            account.VerificationToken = await generateVerificationToken();

            // hash password
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            account.Password = await PasswordEncryptor.EncryptPassword(model.Password, salt);
            account.Salt = Convert.ToBase64String(salt);

            //await _mailService.SendMailConfirmationCode(account);


            // save account
            await _userRepository.CreateAsync(account);
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
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> SendNewPassword(string mail)
        {
            var user = await _userRepository.FindByConditionAsync(x => x.Email == mail);
            var newPass = Guid.NewGuid();
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            user.Password = await PasswordEncryptor.EncryptPassword(newPass.ToString(), salt);
            user.Salt = Convert.ToBase64String(salt);
            //await _mailService.SendMailConfirmationCode(user);
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

