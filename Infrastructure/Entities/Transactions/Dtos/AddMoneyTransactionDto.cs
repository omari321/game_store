using Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Transactions.Dtos
{
    public class AddMoneyTransactionDto
    {
        [Required]
        public double TransactionAmount { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{16})$",
            ErrorMessage = "must be 16 digits")]
        public string CardNumber { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{3}|[0-9]{4})$",
            ErrorMessage = "must be 3 or 4 digits")]
        public string CSV { get; set; }
        [Required]
        public PaymentTypes PaymentType { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
    }
}
