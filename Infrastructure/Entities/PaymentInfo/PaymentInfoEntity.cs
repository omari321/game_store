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
        [MaxLength(32)]
        public string CardNumber { get; set; }
        [MaxLength(16)]
        public string CSV { get; set; }
        [MaxLength(64)]
        public string Salt { get; set; }
        public PaymentTypesEntityEnum PaymentTypeId { get; set; }
        public DateTime ExpireDate { get; set; }

        public List<UserEntity> userEntities { get; set; }
    }
}
