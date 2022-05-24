using Infrastructure.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin
{
    public interface IAdminService
    {
        Task<UserDto> ChangeUserRole(int selfId,RoleChangeDto model);
    }
}
