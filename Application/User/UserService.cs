using Infrastructure.Entities.User;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int?> RegistrerAsync(PassedNewUserDto entity)
        {
            //Todo : need to add validation on some of the fields with the pattern  we learnt (forgot name something with chaining)
            var existingUser = await _userRepository.FindByUserNameAsync(entity.Username);
                if (existingUser != null)
                {
                 throw new Exception("User Already exists");
                }
                else
                {
                    //throw new Exception(" testi");
                    byte[] salt = new byte[128 / 8];
                    RandomNumberGenerator.Fill(salt);
                    var newUser = new UserEntity
                    {
                        UserName = entity.Username,
                        Password = await PasswordEncryptor.EncryptPassword(entity.Password, salt),
                        Salt = Convert.ToBase64String(salt),
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Adress = entity.Adress,
                        TelephoneNumber = entity.TelephoneNumber,
                        RoleId = entity.RoleId,
                        CityId = entity.CityId,
                        DateCreated = DateTime.Now,
                    };
                    await _userRepository.CreateAsync(newUser);
                    //var user = _userRepository.CreateUserAsync(new CreateUserDto(entity.Username,
                    //    await PasswordEncryptor.EncryptPassword(entity.Password ,salt),
                    //      Convert.ToBase64String(salt),entity.FirstName,entity.LastName,
                    //        entity.age,entity.Email,
                    //            entity.Adress, entity.TelephoneNumber, 
                    //                entity.RoleId,entity.CityId
                    //                    ,new DateTime()));
                    _userRepository.Save();
                    return newUser.Id;
                }
            

        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
            var User =await _userRepository.FindByUserNameAsync(username);
            if (User != null)
            {

                var encrypted =await PasswordEncryptor.EncryptPassword(password, Convert.FromBase64String(User.Salt));
                if (encrypted==User.Password)
                {
                    return new UserDto(User.Id,User.UserName,User.RoleId,User.DateCreated);
                }
            }
            throw new Exception("Incorect Input");
        }

        public Task<UserDto> UpdateUserAsync(UpdateUserDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindByIDAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> ChangePasswordAsync(string username, string password, string newPassword)
        {
            throw new NotImplementedException();
            //var existingUser = await _userRepository.FindByUserNameAsync(username);
            //byte[] salt = new byte[128 / 8];
            //RandomNumberGenerator.Fill(salt);
            //var newEncrypted =await PasswordEncryptor.EncryptPassword(newPassword, salt);
            //var success =await _userRepository.UpdatePasswordAsync(new passwordDto(existingUser.Id,username,newEncrypted,Convert.ToBase64String(salt),existingUser.DateCreated, DateTime.Now));
            //return success;
        }
    }
}
