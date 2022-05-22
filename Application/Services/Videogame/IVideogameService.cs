using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameFile.Dtos;
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
        Task<CreatedGameReturnDto> AddGame(AddGameDto model);
        Task<PagingGameDto> UpdateGame(UpdateGameDto model);
        Task<LoadGameDto> LoadGame(int id);
        Task<PageReturnDto<PagingGameDto>> GetAllAsync(QueryParams model);
        Task<PageReturnDto<PagingGameDto>> SearchGames(VideoGameParameters videoGameParameters);
        Task<List<GameNamesDto>> GetNames();
        Task<PageReturnDto<GameInformationForAdminDto>> InformationForAdminDto(QueryParams model);
        Task<PageReturnDto<GameInformationForAdminDto>> SearchInformationForAdmin(QueryParams model, string NameSearchTerm);
        Task<VideogameFileReturnDto> UploadGame(UploadVideogameFileDto model);
        Task<string> ValidateFileDownload(int userId, int videogameId);
        Task<byte[]> DownloadGame(int userId, int videogameId);
    }
}
