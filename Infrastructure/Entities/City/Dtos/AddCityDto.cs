using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.City.Dtos
{
    public class AddCityDto
    {
        [Required]
        public string  CityName { get; set; }
        [Required]
        public string CityCountryName { get; set; }

    }
}
