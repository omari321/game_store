using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category
{
    public interface ICategoryService
    {
        Task<GetCategoriesDto> AddCategory(CreateCategoryDto model);
        Task<List<GetCategoriesDto>> GetCategories();
        Task<PageReturnDto<PagingGameDto>> GetGamesByCategory(QueryParams model, int categoryId);
        Task<PageReturnDto<PagingGameDto>> SearchGamesByCategory(VideoGameParameters model, int categoryId);
        Task<CategoriesByGame> GetCategoriesByGame(int gameId);
    }
}
