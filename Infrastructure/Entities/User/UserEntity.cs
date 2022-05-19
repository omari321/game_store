using Infrastructure.Entities.City;
using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.PaymentCreditentials;
using Infrastructure.Entities.Token;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.UserBalance;
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
        public string UserName { get; set; }
        //USERNAME must be unique
        [MaxLength(64)]
        public string Password { get; set; }
        [MaxLength(64)]
        public string Salt { get; set; }

        [Unicode(true)]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Unicode(true)]
        [MaxLength(128)]
        public string LastName { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue;
        [Unicode(true)]
        [MaxLength(128)]
        public string Adress { get; set; }
        [MaxLength(32)]
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
        public List<PaymentCredentialsEntity> paymentCreditentials { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }
        public List<TransactionsEntity> transactionsEntities { get; set; }
        public List<OwnedGamesEntity> ownedGamesEntities { get; set; }

    }
}
