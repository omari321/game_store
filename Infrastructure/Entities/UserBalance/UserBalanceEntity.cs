using Infrastructure.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.UserBalance
{
    [Table("UserBalanceEntity", Schema = "dbo")]
    public class UserBalanceEntity: BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public double balance { get; set; }
    }
}
