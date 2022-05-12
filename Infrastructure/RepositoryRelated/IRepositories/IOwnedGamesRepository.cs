using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IOwnedGamesRepository:IRepositoryBase<OwnedGamesEntity>
    {
        Task<PageReturnDto<GameNamesDto>> GetOwnedGames(QueryParams model,int userId); 
    }
}
