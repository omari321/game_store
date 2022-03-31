using Application.User;
using Infrastructure.Entities.User;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public record LoginModel([Required] string Username, [Required] string Password);
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IUserService _UserService;
        public AuthController(IUserService userService)
        {
            _UserService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginModel model)
        {
            return Ok(await _UserService.LoginAsync(model.Username, model.Password));
        }
        [HttpPost("RegistrerUser")]
        public async Task<ActionResult<int?>> Registrer(PassedNewUserDto entity)
        {

             return (await _UserService.RegistrerAsync(entity)).Value;
        }


    }
}
