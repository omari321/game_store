using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Country.Dtos
{
    public class GetCountryDto
    {
        public int Id { get; set; }
        public string  CountryName { get; set; }
    }
}
