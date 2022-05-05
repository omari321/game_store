using Infrastructure.Entities.Categories.Dtos;
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
        Task<GamesByCategoryDto> GetGamesByCategory(int categoryId);
        Task<CategoriesByGame> GetCategoriesByGame(int gameId);
    }
}
