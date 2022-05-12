using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.PaymentCreditentials.Dtos
{
    public class UpdateAddPaymentDto
    {
        public string OwnerName { get; set; }
        public string CardNumber { get; set; }
        public string CSV { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
