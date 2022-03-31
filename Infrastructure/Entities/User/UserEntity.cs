using Infrastructure.Entities.City;
using Infrastructure.Entities.PaymentInfo;
using Infrastructure.Entities.UserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User
{
    [Table("User",Schema ="dbo")]
    public class UserEntity:BaseEntity
    {
        [Key]
        public int  Id { get; set; }
        [Unicode(false)]
        [MaxLength(128)]
        [Required]
        public string UserName { get; set; }
        //USERNAME must be unique
        [MaxLength(64)]
        [Required]
        public string Password { get; set; }
        [MaxLength(64)]
        [Required]
        public string Salt { get; set; }

        [Unicode(true)]
        [MaxLength(128)]
        [Required]
        public string  FirstName { get; set; }
        [Unicode(true)]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }
        [Unicode(true)]
        [MaxLength(128)]
        [Required]
        public string Adress { get; set; }
        [MaxLength(32)]
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public RoleFlagEntitysEnum RoleId { get; set; }
        [Required]
        public int CityId { get; set; }
        public CityEntity City { get; set; }

        public int? PaymentInfoId { get; set; }
        public PaymentInfoEntity PaymentInfo { get; set; }

    }
}
