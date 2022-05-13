using AutoMapper;
using Infrastructure.Entities.Categories;
using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.City;
using Infrastructure.Entities.City.Dtos;
using Infrastructure.Entities.Country;
using Infrastructure.Entities.Country.Dtos;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Entities.VideogameImages;
using Infrastructure.Entities.VideogameImages.Dtos;
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
            CreateMap<PublisherEntity, GetGamesByPublisherDto>();
            CreateMap<PublisherEntity, GetPublisherDto>()
                .ForMember(x => x.PublisherId,
                opt => opt.MapFrom(c => c.Id));
            CreateMap<VideogameEntity,PagingGameDto>();
            CreateMap<CityEntity, GetCityDto>();
            CreateMap<CountryEntity,GetCountryDto>()
                .ForMember(x=>x.CountryName,
                opt=>opt.MapFrom(c=>c.Name));
            CreateMap<AddGameDto, VideogameEntity>();
            CreateMap<VideogameEntity,GameNamesDto>();
            CreateMap<CategoryEntity,GetCategoriesDto>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<VideogameImagesEntity, GetImagesDto>()
                 .ForMember(x => x.VideogameId,
                opt => opt.MapFrom(c => c.VideogameId));
        }
            
    }
}
