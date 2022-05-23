using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameRequirements.Dto
{
    public class RequirementsReturnDto
    {
        public int VideogameId { get; set; }
        public string MinRequirements { get; set; }
        public string RecomendedRequirements { get; set; }
    }
}
