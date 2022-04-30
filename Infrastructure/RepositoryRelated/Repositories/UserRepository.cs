using Infrastructure.Entities;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.RepositoryRelated.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
        public async Task<bool> CheckTokenForUnique(string token)
        {
            return await GetAllQuery().AnyAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        }
        public async Task<UserEntity?> GetUserAndToken(LoginDto model)
        {
            return await GetAllQuery().Include(u => u.RefreshTokens).FirstOrDefaultAsync(x => x.UserName == model.UserName);
        }
        public async Task<UserEntity> GetUserByToken(string token)
        {
            return await GetAllQuery().Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
        }
        public async Task<List<UserEntity>> GetMailsForConfirmationAsync()
        {
            try
            {
                var x = GetAllQuery().Where(x=>x.VerificationToken!=null).ToList();
                return x;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
