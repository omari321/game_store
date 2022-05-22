using API.Attributes;
using API.Context;
using API.Middlewares;
using Application.Services.Category;
using Application.Services.UserTransactionsBalance;
using Application.Services.Videogame;
using Application.Services.VideogameImages;
using Application.Services.VideogameLikes;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameFile.Dtos;
using Infrastructure.Entities.VideogameImages.Dtos;
using Infrastructure.Entities.VideogameLikesList.Dtos;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        private readonly IVideogameLikesService _videogameLikesService;
        public VideogameController(IVideogameService videogameService,
            UserContext userContext, ICategoryService categoryService,
            IVideogameImagesService videogameImagesService,
            IUserTransactionsAndBalanceService userTransactionsBalance,
            IConfiguration configuration,
            IVideogameLikesService videogameLikesService)
        {
            _videogameLikesService = videogameLikesService;
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
            //HttpContext.Request.GetEncodedUrl().ToString().Substring(0, HttpContext.Request.GetEncodedUrl().ToString().LastIndexOf("/"));
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
            return Ok( await _videogameService.AddGame(model));
        }
        [HttpPut("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateGame([FromForm]UpdateGameDto model)
        {
            return Ok(await _videogameService.UpdateGame(model));
        }
        [HttpPost("[action]/{gameId}")]
        public async Task<IActionResult> BuyGame(int gameId)
        {
            await _userTransactionsBalance.BuyGame(gameId,(int)_userContext.userId);
            return Ok(new { status = "Game Bought Succesfully" });
        }

        [HttpPost("[action]")]
        [DisableRequestSizeLimit,RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadGame([FromForm]UploadVideogameFileDto model)
        {
            return Ok(await  _videogameService.UploadGame(model));
        }
        [HttpGet("[action]/VideogameId")]
        public async Task<IActionResult> DownloadGame(int VideogameId)
        {
            var fileName = await _videogameService.ValidateFileDownload((int)_userContext.userId, VideogameId);
            return File(await _videogameService.DownloadGame((int)_userContext.userId,VideogameId), "application/octet-stream", fileName);
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
        [AllowAnonymous]
        [HttpGet("[action]/{gameId}")]
        public async Task<IActionResult> LoadGame([FromRoute] int gameId)
        {
            return Ok(await _videogameService.LoadGame(gameId));
        }
        [HttpGet("[action]/{gameId}")]
        public async Task<IActionResult> LoadImages([FromRoute] int gameId)
        {
            return Ok(await _videogameImagesService.GetVideogameImages(gameId));
        }
        [HttpPost("[action]/{gameId}")]
        public async Task<IActionResult> LikeDislikeGame(LikeDislikeDto model, [FromRoute]int gameId)
        {
            return Ok(await _videogameLikesService.LikeDislikeRemoveBothVideogame((int)_userContext.userId,gameId,model));
        }
        [HttpPost("[action]/{gameId}")]
        public async Task<IActionResult> CheckIfLikesGame(LikeDislikeDto model, [FromRoute] int gameId)
        {
            return Ok(await _videogameLikesService.CheckIfLikes((int)_userContext.userId, gameId));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetUserLikedGames([FromQuery]QueryParams model)
        {
            return Ok(await _videogameLikesService.GetUserLikedGamesAsync(model,(int)_userContext.userId));
        }
    }
}
