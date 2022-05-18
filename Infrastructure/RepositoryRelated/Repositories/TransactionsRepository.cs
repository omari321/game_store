using Infrastructure.Entities;
using Infrastructure.Entities.Enums;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.Transactions.Dtos;
using Infrastructure.Paging;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PageReturnDto<UserTransactionsInfoDto>> GetUserTransactions(QueryParams model,int userId)
        {
            var count = await GetAllQuery()
                .Where(x => x.UserId == userId)
                .CountAsync();
            var chunk= await GetAllQuery()
                .Where(x => x.UserId == userId)
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Include(x=>x.User)
                .ToListAsync();
            var returnChunk=chunk.Select(x =>
            {
                return new UserTransactionsInfoDto
                {
                     Action =x.TransactionDescription,
                     TransactionAmount =x.TransactionAmount,
                     transactionType=x.transactionType,
                     paymentType= x.paymentType,
                     CardNumber =x.CardNumber
                };
            });
            return new PageReturnDto<UserTransactionsInfoDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }
    }
}
