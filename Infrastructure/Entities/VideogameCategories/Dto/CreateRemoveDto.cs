using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameCategories.Dto
{
    public class CreateRemoveDto
    {
        public int VideogameId { get; set; }
        public int CategoryId { get; set; }
    }
}
