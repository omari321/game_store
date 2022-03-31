using Infrastructure.Entities.User;
using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.OwnedGames
{
    [Table("OwnedGames",Schema ="dbo")]
    public class OwnedGamesEntity:BaseEntity
    {
        [Key]
        public int VideoGameId { get; set; }
        public VideoGameEntity VideoGame { get; set; }
        [Key]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        public string key { get; set; }
        
    }
}
