using Infrastructure.Entities.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User
{
    public record PassedNewUserDto(string Username,string Password, string FirstName, string LastName, int age, string Email, string Adress, string TelephoneNumber, RoleFlagEntitysEnum RoleId, int CityId);
    public record CreateUserDto(string Username,string Password,string Salt, string FirstName, string LastName, int age, string Email, string Adress, string TelephoneNumber, RoleFlagEntitysEnum RoleId, int CityId, DateTime CreateDate);
    public record UpdateUserDto(int Id, string Username,string Password,string Salt,string FirstName ,string LastName ,int age,string Email,string Adress,string TelephoneNumber, RoleFlagEntitysEnum  RoleId, int CityId,int PaymentInfoId ,DateTime UpdateDate );
    public record UserPasswordDto(int Id, string Username, string Password, string Salt);
    public record UserDto(int Id, string Username, RoleFlagEntitysEnum RoleId,DateTime CreateDate);
    public interface IUserRepository:IRepositoryBase<UserEntity>
    {
        Task<UserEntity> FindByUserNameAsync(string UserName);
        Task<UserEntity> FindByIdAsync(int id);
        Task<UserEntity> UpdateUserAsync(UpdateUserDto entity);
        Task<UserEntity> CreateUserAsync(CreateUserDto entity);
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<int> UpdatePasswordAsync(UserPasswordDto entity);
        
    }
}
