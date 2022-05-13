using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Paging;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(EntityDbContext entityDbContext,IMapper mapper) : base(entityDbContext)
        {
            _mapper = mapper;
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
            return await GetAllQuery().Where(x=>x.MailSent==null).ToListAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAdminsMagers()
        {
            return await GetAllQuery().Where(x => x.Role == Roles.Admin || x.Role == Roles.Manager).ToListAsync();   
        }

        public async Task<PageReturnDto<UserDto>> SearchUser(SearchUserDto model)
        {
            var count=await GetAllQuery().Where(x=>x.UserName.Contains(model.UserName)).CountAsync();
            var items= await GetAllQuery()
                .Where(x => x.UserName.Contains(model.UserName))
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .ToListAsync();
            return new PageReturnDto<UserDto>(_mapper.Map<IEnumerable<UserDto>>(items), count, model.Page, model.ItemsPerPage);
        }
    }
}
