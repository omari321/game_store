using Infrastructure.Entities.GamesCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    [Table("Category", Schema = "dbo")]
    public class GameCategoryEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        
        public List<GamesCategoriesEntity> gamesCategoriesEntities { get; set; }
    }
}
