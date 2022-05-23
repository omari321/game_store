using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameRequirements.Dto
{
    public class UpdateRequirementsDto
    {
        [Required]
        public string MinRequirements { get; set; }
        [Required]
        public string RecomendedRequirements { get; set; }
    }
}
