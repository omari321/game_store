using API.Attributes;
using API.Middlewares;
using Application.Services.Category;
using Application.Services.VideogameCategoryService;
using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories.Dto;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles.Admin, Roles.Manager)]
    public class CategoryController: ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IVideogameCategoryService _videogameCategoryService;
        public CategoryController(ICategoryService categoryService,IVideogameCategoryService videogameCategoryService)
        {
            _categoryService = categoryService;
            _videogameCategoryService = videogameCategoryService;
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }
        [HttpGet("[action]/{categoryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGamesByCategory([FromQuery] QueryParams model, int categoryId)
        {
            return Ok(await _categoryService.GetGamesByCategory(model, categoryId));
        }
        [HttpGet("[action]/{categoryId}")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchGamesByCategory([FromQuery] VideoGameParameters model, int categoryId)
        {
            return Ok(await _categoryService.SearchGamesByCategory(model, categoryId));
        }
        [HttpGet("[action]/{gameId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoriesByGame(int gameId)
        {
            return Ok(await _categoryService.GetCategoriesByGame(gameId));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddGameCategory(CreateRemoveDto model)
        {
            await _videogameCategoryService.AddGameCategory(model);
            return Ok(new { status = "Games' Category has been added" });
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RemoveGameCategory(CreateRemoveDto model)
        {
            await _videogameCategoryService.RemoveGameCategory(model);
            return Ok(new { status = "Games' Category has been removed" });
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCategory(CreateCategoryDto model)
        {
            await _categoryService.AddCategory(model);
            return Ok(new { status = "Category succesfully created" });
        }
    }
}
