using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameRepository:IRepositoryBase<VideogameEntity>
    {
        Task<PageReturnDto<ReturnGameDto>> GetAllGamesAsync(QueryParams model);
        Task<PageReturnDto<ReturnGameDto>> SearchVideoGameAsync(VideoGameParameters videoGameParameters);
    }
}
