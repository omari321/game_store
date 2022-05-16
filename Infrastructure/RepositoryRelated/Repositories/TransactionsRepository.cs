using Infrastructure.Entities;
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
                .Include(x=>x.Videogame)
                .ToListAsync();
            var returnChunk=chunk.Select(x =>
            {
                if (x.VideogameId == null)
                {
                    return new UserTransactionsInfoDto
                    {
                        UserName = x.User.UserName,
                        Action = $"{x.User.UserName} added money ",
                        TransactionAmount = x.TransactionAmount,
                        paymentType = (Entities.Enums.PaymentTypes)x.paymentType,
                        CardNumber = x.CardNumber
                    };
                }
                else
                {

                    return new UserTransactionsInfoDto
                    {
                        UserName = x.User.UserName,
                        Action = $"{x.User.UserName} bought game named {x.Videogame.VideogameName}",
                        TransactionAmount = x.TransactionAmount,
                    };
                    
                }
            });
            return new PageReturnDto<UserTransactionsInfoDto>(returnChunk, count, model.Page, model.ItemsPerPage);
        }
    }
}
