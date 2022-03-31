using Infrastructure.Entities.VideoGame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.GameReviews
{
    [Table("GamesReview",Schema ="dbo")]
    [Index(nameof(GameId), nameof(PositiveReview))]
    public class GameReviewsEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; } 
        public VideoGameEntity Game { get; set; }
        [Required]
        public bool PositiveReview { get; set; }
       
    }
}
