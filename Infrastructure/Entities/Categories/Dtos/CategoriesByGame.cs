using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Categories.Dtos
{
    public class CategoriesByGame
    {
        public int GameId { get; set; }
        public IEnumerable<GetCategoriesDto> Categories { get; set; }
    }
}
