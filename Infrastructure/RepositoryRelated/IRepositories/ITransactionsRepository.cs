using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.Transactions.Dtos;
using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface ITransactionsRepository:IRepositoryBase<TransactionsEntity>
    {
        Task<PageReturnDto<UserTransactionsInfoDto>> GetUserTransactions(QueryParams model, int userId);
    }
}
