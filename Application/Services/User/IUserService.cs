using Infrastructure.Entities.User.Dto;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAdminManagers();
        Task<PageReturnDto<UserDto>> SearchUser(SearchUserDto model);
    }
}
