using AutoMapper;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<RegistrerDto, UserEntity>();
        }
            
    }
}
