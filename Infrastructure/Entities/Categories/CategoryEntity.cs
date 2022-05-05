using Infrastructure.Entities.VideogameCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Categories
{
    [Table("Category", Schema = "dbo")]
    public class CategoryEntity:BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<VideogameCategoryEntity> videogameCategoryEntities{ get; set; }
    }
}
