using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameCategories.Dto
{
    public class CreateRemoveDto
    {
        [Required]
        public int VideogameId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
