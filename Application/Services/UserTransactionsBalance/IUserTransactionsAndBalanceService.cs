using Infrastructure.Entities.Transactions.Dtos;
using Infrastructure.Entities.UserBalance.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserTransactionsBalance
{
    public interface IUserTransactionsAndBalanceService
    {
        Task<GetUserBalanceDto> GetUserBalance(int userId);
        Task<PageReturnDto<UserTransactionsInfoDto>> GetUserTransactionsInfo(QueryParams model, int userId);
        Task<bool> AddMoneyTransaction(AddMoneyTransactionDto model);
        Task<bool> BuyGame(int gameId,int userId);
    }
}
