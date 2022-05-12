using API.Attributes;
using API.Middlewares;
using Application.Services.Category;
using Application.Services.Videogame;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles.Admin,Roles.Manager)]
    public class VideogameController: ControllerBase
    {
        private readonly IVideogameService _videogameService;
        private readonly ICategoryService _categoryService;
        public VideogameController(IVideogameService videogameService)
        {
            _videogameService = videogameService;
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
        [HttpPost("[action]")]
        [DisableRequestSizeLimit,RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadGame(IFormFile file)
        {
            await _videogameService.UploadGame(file);
            return Ok(new {status="file uploaded successfully"});
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> LoadGame([FromRoute] int id)
        {
            return Ok(_videogameService.LoadGame(id));
        }

    }
}
