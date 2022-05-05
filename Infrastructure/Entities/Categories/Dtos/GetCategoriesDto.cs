using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Categories.Dtos
{
    public class GetCategoriesDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
