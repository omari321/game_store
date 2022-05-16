using Infrastructure.Entities.Enums;
using Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.PaymentCreditentials
{
    [Table("PaymentCreditentials", Schema = "dbo")]
    public class PaymentCredentialsEntity :BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Unicode(true)]
        [MaxLength(64)]
        public string OwnerName { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [MaxLength(32)]
        public string CardNumber { get; set; }
        [MaxLength(16)]
        public string CSV { get; set; }
        public PaymentTypes PaymentTypeId { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
