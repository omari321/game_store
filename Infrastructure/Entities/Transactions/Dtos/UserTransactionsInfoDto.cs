using Infrastructure.Entities.Enums;
using Infrastructure.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Transactions.Dtos
{
    public class UserTransactionsInfoDto
    {
        public string UserName { get; set; }
        public string  Action { get; set; }
        
        public double TransactionAmount { get; set; }
        public PaymentTypes paymentType { get; set; }
        public string CardNumber { get; set; }
    }
}
