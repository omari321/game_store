using Infrastructure.Entities.User;
using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.BoughtGames
{
    [Table("BoughtGames",Schema ="dbo")]
    public class BoughtGamesEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VideoGameId { get; set; }
        public VideoGameEntity VideoGameEntity { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        public bool IsDigital { get; set; }
        [Required]
        public string key { get; set; }
        [Required]
        public double BoughtPrice { get; set; }
    }
}
