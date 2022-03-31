using Infrastructure.Entities.User;
using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.UserShoppingCart
{
    [Table("UserShoppingCart",Schema =("dbo"))]
    public class UserShoppingCartEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VideoGameId { get; set; }
        public VideoGameEntity VideoGame { get; set; }
        [Required]
        public int UserId { get; set; } 
        
        public UserEntity User { get; set; }
    }
}
