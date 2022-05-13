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
        Task<PageReturnDto<PagingGameDto>> GetAllGamesAsync(QueryParams model);
        Task<PageReturnDto<PagingGameDto>> SearchVideoGameAsync(VideoGameParameters videoGameParameters);
        Task<PageReturnDto<GameInformationForAdminDto>> InformationForAdminDto(QueryParams model);
        Task<PageReturnDto<GameInformationForAdminDto>> SearchInformationForAdmin(QueryParams model,string NameSearchTerm);
        Task<LoadGameDto> LoadGame(int id);
        Task<VideogameEntity> GetEntityByIdForAddingImagesOnly(int gameId);
    }
}
