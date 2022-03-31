using Infrastructure.Entities.VideoGame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.GameVisits
{
    [Table("GameVisits",Schema =("dbo"))]
    [Index(nameof(GameId))]
    public class GameVisitsEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }
        public VideoGameEntity Game { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
    }
}
