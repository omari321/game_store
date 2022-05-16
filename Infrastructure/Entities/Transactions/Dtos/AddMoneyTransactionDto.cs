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
        public int UserId { get; set; }
        [Required]
        public double TransactionAmount { get; set; }
    }
}
