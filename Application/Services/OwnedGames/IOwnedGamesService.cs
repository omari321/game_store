using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OwnedGames
{
    public interface IOwnedGamesService
    {
        Task<bool> CheckIfOwnsGame(int userId,int gameId);
        Task<bool> AdminAddGameForUser(int userId, int gameId);
        Task<PageReturnDto<GameNamesDto>> GetUserOwnedGames(QueryParams model,int userId);
    }
}
