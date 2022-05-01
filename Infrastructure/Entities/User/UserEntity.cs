using Infrastructure.Entities.City;
using Infrastructure.Entities.PaymentInfo;
using Infrastructure.Entities.Token;
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
        public int Id { get; set; }
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
        public string FirstName { get; set; }
        [Unicode(true)]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue;
        [Unicode(true)]
        [MaxLength(128)]
        [Required]
        public string Adress { get; set; }
        [MaxLength(32)]
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Roles Role { get; set; }
        [Required]
        public int CityId { get; set; }
        public CityEntity City { get; set; }

        public PaymentInfoEntity? PaymentInfo { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
