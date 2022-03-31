using Infrastructure.Entities.User;
using Infrastructure.Entities.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public interface IUserService
    {
        Task<UserDto> LoginAsync(string username, string password);
        Task<int?> RegistrerAsync(PassedNewUserDto entity);
        Task<UserDto> UpdateUserAsync(UpdateUserDto entity);
        Task<bool> ChangePasswordAsync(string username, string password,string newPassword);
        Task<UserDto> FindByIDAsync(int Id);
    }
}
