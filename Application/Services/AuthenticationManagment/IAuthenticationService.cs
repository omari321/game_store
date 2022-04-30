using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthenticationManagment
{
    public interface IAuthenticationService
    {
        Task<AuthenticateResponse> Authenticate(LoginDto model, string ipAddress);
        Task<AuthenticateResponse> RefreshToken(string token, string ipAddress);
        Task<bool> RevokeToken(string token, string ipAddress);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetById(int id);
        Task<bool> RegisterUser(RegistrerDto model);
        Task<bool> VerifyEmail(string token);
        Task<bool> SendNewPassword(string mail);
        Task<bool> ChangePassword(NewPasswordDto model,int userId);
    }
}
