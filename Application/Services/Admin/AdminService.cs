using Application.Exceptions;
using Infrastructure.Entities.User.Dto;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public AdminService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<UserDto> ChangeUserRole(int selfId,RoleChangeDto model)
        {
            var user = await _userRepository.FindByConditionAsync(x => x.UserName == model.UserName);
            if (user==null)
            {
                throw new CustomException("this user does not exist ", 400);
            }
            if (selfId == user.Id)
            {
                throw new CustomException("user cant change his own role", 400);
            }
                user.Role = model.newRole;
            await _unitOfWork.CompleteAsync();
            return new UserDto
            {
                Id=user.Id,
                UserName=user.UserName,
                Role=user.Role,
                Email=user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName,
                TelephoneNumber=user.TelephoneNumber,
            };
        }
    }
}
