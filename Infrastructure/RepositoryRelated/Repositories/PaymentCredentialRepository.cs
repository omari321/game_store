using Infrastructure.Entities;
using Infrastructure.Entities.PaymentCreditentials;
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
    public class PaymentCredentialRepository : RepositoryBase<PaymentCredentialsEntity >, IPaymentCredentialRepository 
    {
        public PaymentCredentialRepository(EntityDbContext entityDbContext) : base(entityDbContext)
        {
        }

        public async Task<List<PaymentCredentialsEntity>> GetUserPaymentCreditentials(int userId)
        {
            return await GetAllQuery().Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
