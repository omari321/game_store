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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Application.Services.EnumCollections;
using Application.Services.User;
using Application.Services.OwnedGames;
using Application.Services.UserTransactionsBalance;
using API.Context;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles.Admin)]
    
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _AdminService;
        private readonly IVideogameService _videogameService;
        private readonly ICityCountryService _cityCountryService;
        private readonly IEnumCollections _enumCollection;
        private readonly IUserService _userService;
        private readonly IOwnedGamesService _ownedGamesService;
        private readonly IUserTransactionsAndBalanceService _userTransactionsAndBalance;
        private readonly UserContext _userContext;
        public AdminController(IAdminService adminService, 
            UserContext userContext,
            IVideogameService videogameService,
            ICityCountryService cityCountryService,
            IEnumCollections enumCollection, 
            IUserService userService, 
            IOwnedGamesService ownedGamesService, 
            IUserTransactionsAndBalanceService userTransactionsAndBalance)
        {
            _AdminService = adminService;
            _videogameService = videogameService;
            _cityCountryService = cityCountryService;
            _enumCollection = enumCollection;
            _userService = userService;
            _ownedGamesService = ownedGamesService;
            _userTransactionsAndBalance = userTransactionsAndBalance;
            _userContext = userContext;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeUserRole(RoleChangeDto model)
        {
            return Ok(await _AdminService.ChangeUserRole((int)_userContext.userId,model));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCountry(AddCountryDto model)
        {
            return Ok( await _cityCountryService.AddCountry(model));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCity(AddCityDto model)
        {
            return Ok( await _cityCountryService.AddCity(model));
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
        [HttpGet("[action]/{SearchName}")]
        public async Task<IActionResult> SearchGameInformationForAdmin([FromQuery] QueryParams model,string SearchName)
        {
            return Ok(await _videogameService.SearchInformationForAdmin(model,SearchName));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GameInformationForAdmin([FromQuery] QueryParams model)
        {
            return Ok(await _videogameService.InformationForAdminDto(model));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(_enumCollection.GetRoles());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAdminManagerUsers()
        {
            return Ok(await _userService.GetAdminManagers());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchUserInfo([FromQuery]SearchUserDto model)
        {
            return Ok(await _userService.SearchUser(model));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserBalance(int userId)
        {
            return Ok(await _userTransactionsAndBalance.GetUserBalance(userId));
        }
        [HttpGet("[action]/{userId}")]
        public async Task<IActionResult> GetUserTransactionsInfo([FromQuery] QueryParams model,int userId)
        {
            return Ok(await _userTransactionsAndBalance.GetUserTransactionsInfo(model, userId));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGameForUser(int userId,int gameId)
        {
            await _ownedGamesService.AdminAddGameForUser(userId, gameId);
            return Ok(new { status = "game added succesfully" }) ;
        }
        [HttpGet("[action]/userId")]
        public async Task<IActionResult> GetUserOwnedGames([FromQuery] QueryParams model,int userId)
        {
            return Ok( await _ownedGamesService.GetUserOwnedGames(model, userId));
        }
    }
}
