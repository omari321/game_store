using AutoMapper;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAdminManagers()
        {
            var items=await _userRepository.GetAdminsMagers();
            return _mapper.Map<IEnumerable<UserDto>>(items);
        }

        public async Task<PageReturnDto<UserDto>> SearchUser(SearchUserDto model)
        {
            return await _userRepository.SearchUser(model);   
        }
    }
}
