using Infrastructure.Entities.Categories;
using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameCategories
{
    [Table("VideogameCategory", Schema = "dbo")]
    public class VideogameCategoryEntity:BaseEntity
    {
        [Key]
        public int VideogameId { get; set; }
        public VideogameEntity Videogame { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
