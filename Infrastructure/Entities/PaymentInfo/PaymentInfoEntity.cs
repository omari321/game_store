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

namespace Infrastructure.Entities.PaymentInfo
{
    [Table("PaymentInfo",Schema ="dbo")]
    public class PaymentInfoEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Unicode(true)]
        [Required]
        [MaxLength(64)]
        public string OwnerName { get; set; }
        //todo:  momavalshi ,Dasa hesh ia
        [Required]
        [MaxLength(32)]
        public string CardNumber { get; set; }
        [Required]
        [MaxLength(16)]
        public string CSV { get; set; }
        [Required]
        [MaxLength(64)]
        public string Salt { get; set; }
        [Required]
        public PaymentTypesEntityEnum PaymentTypeId { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }

        public List<UserEntity> userEntities { get; set; }
    }
}
