using API.Attributes;
using API.Middlewares;
using Application.Services.Videogame;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] 
    [Authorize(Roles.Admin,Roles.Manager)]
    public class VideogameController: ControllerBase
    {
        private readonly IVideogameService _videogameService;
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
    }
}
