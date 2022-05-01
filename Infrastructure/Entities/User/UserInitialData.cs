using Infrastructure.Entities.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User
{
    public class UserInitialData: IEntityTypeConfiguration<UserEntity>
    {
        public async void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            byte[] salt = new byte[128 / 8];
            RandomNumberGenerator.Fill(salt);
            var Password = await PasswordEncryptor.EncryptPassword("string", salt);
            var Salt =   Convert.ToBase64String(salt);
            builder.HasData
                (
                    new UserEntity
                    {
                        Id = 1,
                        UserName = "string",
                        Password = Password,
                        Salt = Salt,
                        FirstName = "admin",
                        LastName = "admin",
                        Adress = "admin",
                        Verified=DateTime.Now,
                        TelephoneNumber = "551001100",
                        Email = "O_pirtskhalaishvili@cu.edu.ge",
                        Role = Roles.Admin,
                        CityId = 1
                    }
                );
        }
    }
}
