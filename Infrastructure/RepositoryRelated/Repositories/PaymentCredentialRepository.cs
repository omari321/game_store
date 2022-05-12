using Infrastructure.Entities;
using Infrastructure.Entities.PaymentCreditentials;
using Infrastructure.Repositories;
using Infrastructure.RepositoryRelated.IRepositories;
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
    }
}
