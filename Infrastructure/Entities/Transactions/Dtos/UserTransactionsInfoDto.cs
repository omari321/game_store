using Infrastructure.Entities.Enums;
using Infrastructure.Entities.User;
using Infrastructure.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Transactions.Dtos
{
    public class UserTransactionsInfoDto
    {
        public string  Action { get; set; }

        public TransactionType transactionType { get; set; }
        public double TransactionAmount { get; set; }
        public PaymentTypes? paymentType { get; set; }
        public string? CardNumber { get; set; }
    }
}
