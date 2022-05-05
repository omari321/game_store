using API.Attributes;
using API.Middlewares;
using Application.Services.Admin;
using Application.Services.Category;
using Application.Services.CityCountry;
using Application.Services.Publisher;
using Application.Services.Videogame;
using Application.Services.VideogameCategoryService;
using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.City.Dtos;
using Infrastructure.Entities.Country.Dtos;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories.Dto;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles.Admin)]
    
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _AdminService;
        private readonly ICityCountryService _cityCountryService;
        private readonly IPublisherService _publisherService;
        private readonly IVideogameService _videogameService;
        private readonly ICategoryService _categoryService;
        private readonly IVideogameCategoryService _videogameCategoryService;
        public AdminController(IAdminService AdminService, ICityCountryService cityCountryService,IPublisherService publisherService, IVideogameService videogameService,
            ICategoryService categoryService,IVideogameCategoryService videogameCategoryService)
        {
            _AdminService = AdminService;
            _cityCountryService = cityCountryService;
            _publisherService = publisherService;
            _videogameService = videogameService;
            _categoryService = categoryService;
            _videogameCategoryService = videogameCategoryService;
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeUserRole(RoleChangeDto model)
        {
            return Ok(await _AdminService.ChangeUserRole(model));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCountry(AddCountryDto model)
        {
            await _cityCountryService.AddCountry(model);
            return Ok(new {status="Country Added Succesfully"});
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCity(AddCityDto model)
        {
            await _cityCountryService.AddCity(model);
            return Ok(new { status = "City Added Succesfully" });
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddPublisher(AddPublisherDto model)
        {
            await _publisherService.AddPublisher(model);
            return Ok(new { status = "Publisher Added Succesfully" });
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddGame(AddGameDto model)
        {
            await _videogameService.AddGame(model);
            return Ok(new { status = "Game Added Succesfully" });
        }
        [HttpPut("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGame(UpdateGameDto model)
        {
            await _videogameService.UpdateGame(model);
            return Ok(new { status = "Game updated Succesfully" });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCities()
        {          
            return Ok(await _cityCountryService.GetAllCities());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _cityCountryService.GetAllCountries());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPublisers()
        {
            return Ok(await _publisherService.GetPublishers());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetGameByPublisher(string name)
        {
            return Ok(await _publisherService.GetGamesByPublisher(name));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(CreateCategoryDto model)
        {
            await _categoryService.AddCategory(model);
            return Ok(new {status="Category succesfully created"});
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetCategories());
        }
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetGamesByCategory(int categoryId)
        {
            return Ok(await _categoryService.GetGamesByCategory(categoryId));
        }
        [HttpGet("[action]/{gameId}")]
        public async Task<IActionResult> GetCategoriesByGame(int gameId)
        {
            return Ok(await _categoryService.GetCategoriesByGame(gameId));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGameCategory(CreateRemoveDto model)
        {
            await _videogameCategoryService.AddGameCategory(model);
            return Ok(new {status="Games' Category has been added"});
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveGameCategory(CreateRemoveDto model)
        {
            await _videogameCategoryService.RemoveGameCategory(model);
            return Ok(new { status = "Games' Category has been removed" });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync([FromQuery]QueryParams model)
        {
            return Ok(await _videogameService.GetAllAsync(model));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchGames([FromQuery]VideoGameParameters videoGameParameters)
        {
            return Ok(await _videogameService.SearchGames(videoGameParameters)); 
        }
    }
}
