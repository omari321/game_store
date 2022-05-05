using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Videogame
{
    public interface IVideogameService
    {
        Task AddGame(AddGameDto model);
        Task UpdateGame(UpdateGameDto model);
        Task<VideogameEntity> VisitGame(int id);
        Task<PageReturnDto<ReturnGameDto>> GetAllAsync(QueryParams model);
        Task<PageReturnDto<ReturnGameDto>> SearchGames(VideoGameParameters videoGameParameters);
        Task<List<GameNamesDto>> GetNames();
    }
}
