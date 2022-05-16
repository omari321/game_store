using API.Attributes;
using API.Context;
using API.Middlewares;
using Application.Services.Category;
using Application.Services.UserTransactionsBalance;
using Application.Services.Videogame;
using Application.Services.VideogameImages;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameImages.Dtos;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles.Admin,Roles.Manager,Roles.NormalUser)]
    public class VideogameController: ControllerBase
    {
        private readonly IVideogameService _videogameService;
        private UserContext _userContext;
        private readonly ICategoryService _categoryService;
        private readonly IVideogameImagesService _videogameImagesService;
        private readonly IUserTransactionsAndBalanceService _userTransactionsBalance;

        public VideogameController(IVideogameService videogameService,
            UserContext userContext, ICategoryService categoryService,
            IVideogameImagesService videogameImagesService,
            IUserTransactionsAndBalanceService userTransactionsBalance)
        {
            _videogameService = videogameService;
            _userContext = userContext;
            _categoryService = categoryService;
            _videogameImagesService = videogameImagesService;
            _userTransactionsBalance = userTransactionsBalance;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryParams model)
        {
            return Ok(await _videogameService.GetAllAsync(model));
        }
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchGames([FromQuery] VideoGameParameters videoGameParameters)
        {
            return Ok(await _videogameService.SearchGames(videoGameParameters));
        }
        [AllowAnonymous]
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetGamesByCategory([FromQuery] QueryParams model, int categoryId)
        {
            return Ok(await _categoryService.GetGamesByCategory(model, categoryId));
        }
        [AllowAnonymous]
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> SearchGamesByCategory([FromQuery] VideoGameParameters model, int categoryId)
        {
            return Ok(await _categoryService.SearchGamesByCategory(model,categoryId));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddGame([FromForm]AddGameDto model)
        {
            await _videogameService.AddGame(model);
            return Ok(new { status = "Game Added Succesfully" });
        }
        [HttpPut("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGame([FromForm]UpdateGameDto model)
        {
            await _videogameService.UpdateGame(model);
            return Ok(new { status = "Game updated Succesfully" });
        }
        [HttpPost("[action]/{gameId}")]
        public async Task<IActionResult> BuyGame(int gameId)
        {
            await _userTransactionsBalance.BuyGame(gameId,(int)_userContext.userId);
            return Ok(new { status = "Game Bought Succesfully" });
        }

        //NOT WORKING
        [HttpPost("[action]")]
        [DisableRequestSizeLimit,RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadGame(IFormFile file)
        {
            await  _videogameService.UploadGame(file);
            return Ok(new {status="file uploaded successfully"});
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddImagesToGame([FromForm]AddImagesDto model)
        {
            return Ok(await _videogameImagesService.AddImagesToGame(model));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteGameImage(RemoveImageDto model)
        {
            return Ok(await _videogameImagesService.RemoveImage(model));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> LoadGame([FromRoute] int id)
        {
            return Ok(await _videogameService.LoadGame(id));
        }
        [HttpGet("[action]/{gameId}")]
        public async Task<IActionResult> LoadImages([FromRoute] int gameId)
        {
            return Ok(await _videogameImagesService.GetVideogameImages(gameId));
        }

    }
}
