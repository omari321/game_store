using Infrastructure.Entities.PaymentCreditentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IPaymentCredentialRepository :IRepositoryBase<PaymentCredentialsEntity >
    {
        Task<List<PaymentCredentialsEntity>> GetUserPaymentCreditentials(int userId);
    }
}
