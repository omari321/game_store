using Infrastructure.Entities.PaymentCreditentials.Dtos;
using Infrastructure.Entities.Videogame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentCreditentials
{
    public interface IPaymentCreditentialsService
    {
        Task<PaymentCredentialsInfoDto> UpdateAddPayment(int id, UpdateAddPaymentDto model);
        Task<PaymentCredentialsInfoDto> GetUserPaymentCreditentials(int userId);
    }
}
