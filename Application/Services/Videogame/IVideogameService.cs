using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Http;
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
        Task<LoadGameDto> LoadGame(int id);
        Task<PageReturnDto<PagingGameDto>> GetAllAsync(QueryParams model);
        Task<PageReturnDto<PagingGameDto>> SearchGames(VideoGameParameters videoGameParameters);
        Task<List<GameNamesDto>> GetNames();
        Task<PageReturnDto<GameInformationForAdminDto>> InformationForAdminDto(QueryParams model);
        Task<PageReturnDto<GameInformationForAdminDto>> SearchInformationForAdmin(QueryParams model, string NameSearchTerm);
        Task GetVideogameImages(int VideogameId); 
        Task<bool> UploadGame(IFormFile File);
        Task<bool> DownloadGame(IFormFile File);
        Task<bool> AddVideogameImages(int gameId, IEnumerable<IFormFile> files);
    }
}
