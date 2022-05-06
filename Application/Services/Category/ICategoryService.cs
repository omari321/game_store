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
        Task AddCategory(CreateCategoryDto model);
        Task<List<GetCategoriesDto>> GetCategories();
        Task<PageReturnDto<ReturnGameDto>> GetGamesByCategory(QueryParams model, int categoryId);
        Task<PageReturnDto<ReturnGameDto>> SearchGamesByCategory(VideoGameParameters model, int categoryId);
        Task<CategoriesByGame> GetCategoriesByGame(int gameId);
    }
}
