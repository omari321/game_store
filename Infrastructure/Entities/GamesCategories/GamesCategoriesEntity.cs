using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.GamesCategories
{
    [Table("GameCategories", Schema = "dbo")]
    public class GamesCategoriesEntity:BaseEntity
    {
        [Key]
        public int GameId { get; set; }
        public VideoGameEntity Game { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public GameCategoryEntity Category { get; set; }

    }
}
