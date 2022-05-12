using Infrastructure.Entities;
using Infrastructure.Entities.Transactions;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.Repositories
{
    public class TransactionsRepository : RepositoryBase<TransactionsEntity>, ITransactionsRepository
    {
        public TransactionsRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }
    }
}
