using API.Attributes;
using API.Context;
using API.Middlewares;
using Application.Services.AuthenticationManagment;
using Application.Services.PaymentCreditentials;
using Application.Services.OwnedGames;
using Infrastructure.Entities.PaymentCreditentials.Dtos;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Paging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles.NormalUser,Roles.Manager, Roles.Admin)]
    public class UserFunctions:ControllerBase
    {
        private readonly IPaymentCreditentialsService _paymentCreditentialsService;
        private readonly UserContext _userContext;
        private readonly IAuthenticationService _authenticationService;
        private readonly IOwnedGamesService _ownedGamesService;
        public UserFunctions(IPaymentCreditentialsService paymentCreditentialsService, UserContext userContext,IAuthenticationService authenticationService, IOwnedGamesService ownedGamesService)
        {
            _paymentCreditentialsService = paymentCreditentialsService;
            _userContext = userContext;
            _authenticationService = authenticationService; 
            _ownedGamesService = ownedGamesService;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddUpdatePaymentCreditentials(UpdateAddPaymentDto model)
        {
            return Ok(await _paymentCreditentialsService.UpdateAddPayment((int)_userContext.userId,model));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangePassword(NewPasswordDto model)
        {
            var res = await _authenticationService.ChangePassword(model, (int)_userContext.userId);
            return Ok(res);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CheckIfOwnsGame(int id)
        {
            return Ok(await _ownedGamesService.CheckIfOwnsGame(id,(int)_userContext.userId));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetOwnedGames([FromQuery]QueryParams model)
        {
            return Ok(await _ownedGamesService.GetUserOwnedGames(model,(int)_userContext.userId));
        }
        //update password
        //update user information
        //add payment creditentials
        //update payment creditentials
        //get my games
        //get my comments
        //get my favorited games
        //get my transaction history
    }
}
