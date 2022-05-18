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
using Application.Services.UserTransactionsBalance;
using Infrastructure.Entities.Transactions.Dtos;

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
        private readonly IUserTransactionsAndBalanceService _userTransactionsBalance;

        public UserFunctions(IPaymentCreditentialsService paymentCreditentialsService,
            UserContext userContext, IAuthenticationService authenticationService,
            IOwnedGamesService ownedGamesService,
             IUserTransactionsAndBalanceService userTransactionsBalance)
        {
            _paymentCreditentialsService = paymentCreditentialsService;
            _userContext = userContext;
            _authenticationService = authenticationService;
            _ownedGamesService = ownedGamesService;
            _userTransactionsBalance = userTransactionsBalance;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserPaymentCreditentials()
        {
            return Ok(await _paymentCreditentialsService.GetUserPaymentCreditentials((int)_userContext.userId));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CheckIfOwnsGame(int gameId)
        {
            return Ok(await _ownedGamesService.CheckIfOwnsGame(gameId,(int)_userContext.userId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserOwnedGames([FromQuery] QueryParams model)
        {
            return Ok(await _ownedGamesService.GetUserOwnedGames(model,(int)_userContext.userId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserTransactionsInfo([FromQuery] QueryParams model)
        {
            return Ok(await _userTransactionsBalance.GetUserTransactionsInfo(model, (int)_userContext.userId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserBalance()
        {
            return Ok(await _userTransactionsBalance.GetUserBalance((int)_userContext.userId));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddMoneyOnBalance(AddMoneyTransactionDto model)
        {
            return Ok(await _userTransactionsBalance.AddMoneyOnBalance((int)_userContext.userId,model));
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
    }
}
