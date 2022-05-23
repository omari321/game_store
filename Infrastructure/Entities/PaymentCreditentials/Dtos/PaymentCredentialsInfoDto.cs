using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.PaymentCreditentials.Dtos
{
    public class PaymentCredentialsInfoDto
    {
        public string? OwnerName { get; set; }
        public PaymentTypes? PaymentTypes { get; set; }
        public string? CardNumber { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
