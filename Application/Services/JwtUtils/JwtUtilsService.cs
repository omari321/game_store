using Infrastructure.Entities.Token;
using Infrastructure.Entities.User;
using Infrastructure.Entities.UserRepo;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.JwtUtils
{
    public class JwtUtilsService:IJwtUtilsService
    {
        private IUserRepository _userRepository;
        private readonly JwtSettings _JwtSettings;

        public JwtUtilsService(
            IUserRepository userRepository,
            IOptions<JwtSettings> appSettings)
        {
            _userRepository = userRepository;
            _JwtSettings = appSettings.Value;
        }

        public string GenerateJwtToken(UserEntity user)
        {
            // generate token that is valid for 15 minutes
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Issuer = _JwtSettings.Issuer,
                Audience = _JwtSettings.Audiance,
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_JwtSettings.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _JwtSettings.Issuer,
                    ValidAudience = _JwtSettings.Audiance,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ValidateLifetime = true,
                    LifetimeValidator= (DateTime? notBefore, DateTime? expires, SecurityToken token, TokenValidationParameters @params)=>
                    {
                        if (expires != null)
                        {
                            return expires > DateTime.UtcNow;
                        }
                        return false;
                    },    
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);


                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        public async Task<RefreshToken> GenerateRefreshTokenAsync(string ipAddress)
        {
            var refreshToken = new RefreshToken
            {
                Token = await getUniqueTokenAsync(),
                role = Roles.NormalUser,
                // token is valid for 7 days
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };

            return refreshToken;

            async Task<string> getUniqueTokenAsync()
            {
                var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                var tokenIsUnique = await _userRepository.CheckTokenForUnique(token);

                if (tokenIsUnique)
                    return await getUniqueTokenAsync();

                return token;
            }
        }

    }
}

