using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IUserRepository:IRepositoryBase<UserEntity>
    {
        Task<bool> CheckTokenForUnique(string token);
        Task<UserEntity?> GetUserAndToken(LoginDto model);
        Task<UserEntity> GetUserByToken(string token);
        //Task<List<UserEntity>> GetMailsForConfirmationAsync();
        Task<IEnumerable<UserEntity>> GetAdminsMagers();
        Task<PageReturnDto<UserDto>> SearchUser(SearchUserDto model);
    }
}
