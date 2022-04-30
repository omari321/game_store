using Infrastructure.Entities.Token;
using Infrastructure.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.JwtUtils
{
    public interface IJwtUtilsService
    {
        public string GenerateJwtToken(UserEntity user);
        public int? ValidateJwtToken(string token);
        public Task<RefreshToken> GenerateRefreshTokenAsync(string ipAddress);
    }
}
