using Infrastructure.Entities.VideogameLikes.Dtos;
using Infrastructure.Entities.VideogameLikesList.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameLikes
{
    public interface IVideogameLikesService
    {
        Task<VideogameLikesReturnDto> LikeDislikeRemoveBothVideogame(int userId,int videogameId, LikeDislikeDto model);
        Task<CheckIFuserLikedDto> CheckIfLikes(int userId, int videogameId);
        Task<PageReturnDto<UserGameIsLikedDto>> GetUserLikedGamesAsync(QueryParams model, int userId);
    }
}
