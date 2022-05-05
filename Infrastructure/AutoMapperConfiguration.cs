using AutoMapper;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<VideogameEntity, ReturnGameDto>();
        }
    }
}
