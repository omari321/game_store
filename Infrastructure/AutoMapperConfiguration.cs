using AutoMapper;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameLikesList;
using Infrastructure.Entities.VideogameLikesList.Dtos;
using Infrastructure.RepositoryRelated.Repositories;
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

            CreateMap<VideogameEntity, PagingGameDto>()
                .ForMember(x => x.TotalDislikes,
                opt => opt.MapFrom(z => z.VideogameLikesEntities.First().DislikesCount));
            CreateMap<VideogameEntity, LoadGameDto>()
                .ForMember(x => x.PublicsherId,
                opt => opt.MapFrom(z => z.Publicsher.Id))
                .ForMember(x => x.PublisherName,
                opt => opt.MapFrom(z => z.Publicsher.PublisherName))
                .ForMember(x => x.TotalLikes,
                opt => opt.MapFrom(z => z.VideogameLikesEntities.First().LikesCount))
                .ForMember(x => x.TotalDislikes,
                opt => opt.MapFrom(z => z.VideogameLikesEntities.First().DislikesCount));
            CreateMap<UserEntity, UserDto>();
            CreateMap<OwnedGamesEntity, GameNamesDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(z => z.VideogameId))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(z => z.Videogame.VideogameName));
            CreateMap<VideogameLikesListEntity, UserGameIsLikedDto>();
        }
    }
}
