using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(EntityDbContext entityDbContext):base(entityDbContext)
        {
        }
        public async Task<UserEntity> CreateUserAsync(CreateUserDto entity)
        {
            var user = new UserEntity
            {
                UserName=entity.Username,
                Password=entity.Password,
                Salt=entity.Salt,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Adress=entity.Adress,  
                TelephoneNumber=entity.TelephoneNumber,
                RoleId=entity.RoleId,
                CityId=entity.CityId,
                DateCreated=DateTime.Now,
            };
            var User=await _entityDbContext.userEntities
                .AddAsync(user);
            var answer= _entityDbContext.SaveChanges();
            return User.Entity;
        }

        public Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> FindByUserNameAsync(string UserName)
        {
            return await _entityDbContext.userEntities.FirstOrDefaultAsync(x => x.UserName == UserName);
        }

        public Task<int> UpdatePasswordAsync(UserPasswordDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateUserAsync(UpdateUserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
