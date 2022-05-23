using API.Attributes;
using API.Context;
using API.Extensions;
using API.Middlewares;
using Application.Services.AuthenticationManagment;
using Application.Services.Mail;
using Infrastructure.Entities.User;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles.NormalUser,Roles.Manager, Roles.Admin)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserContext _userContext;
        private readonly IMailService _mailService;
        public AuthController(IAuthenticationService authenticationService,UserContext userContext, IMailService mailService)
        {
            _authenticationService = authenticationService;
            _userContext = userContext;
            _mailService = mailService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate(LoginDto model)
        {
            var response = await _authenticationService.Authenticate(model,_userContext.ClientIpAddress);
            this.SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _authenticationService.RefreshToken(refreshToken, _userContext.ClientIpAddress);
            
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string mail)
        {
            var res = await _authenticationService.SendNewPassword(mail);
            return Ok(res);
        }

        [HttpPost("revoke-token")]
        //drois gasvlaze armaq shemocmeba martivi dasamatebelia ubralod gatestvisas xels shemishlis
        public async Task<IActionResult> RevokeToken()
        {
            var token =  Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            await _authenticationService.RevokeToken(token, _userContext.ClientIpAddress);
            return Ok(new { message = "Token revoked" });
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Registrer(RegistrerDto model)
        {
            //HttpContext.Request.GetEncodedUrl().ToString().Substring(0, HttpContext.Request.GetEncodedUrl().ToString().LastIndexOf("/"));
            var res = await _authenticationService.RegisterUser(model);
            return Ok(new {status="registration successfull you will soon recieve link on email pls confirm" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _authenticationService.GetAll();
            return Ok(users);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _authenticationService.GetById(id);
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpGet("[action]/{token}")]
        public async Task<IActionResult> VerifyEmail([FromRoute]string token)
        {
            await _authenticationService.VerifyEmail(token);
            return Ok(new { message = "Verification successful, you can now login" });
        }

    }
}
