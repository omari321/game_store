using Infrastructure.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface ITransactionsRepository:IRepositoryBase<TransactionsEntity>
    {
    }
}
