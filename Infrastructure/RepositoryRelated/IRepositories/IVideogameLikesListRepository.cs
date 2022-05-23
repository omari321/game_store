using Infrastructure.Entities.VideogameLikesList;
using Infrastructure.Entities.VideogameLikesList.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameLikesListRepository:IRepositoryBase<VideogameLikesListEntity>
    {
        Task<PageReturnDto<UserGameIsLikedDto>> GetUserLikedGamesAsync(QueryParams model, int userId);
    }
}
