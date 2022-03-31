using Infrastructure.Entities.City;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Country
{
    [Table("Country",Schema ="dbo")]
    public class CountryEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Unicode(true)]
        [StringLength(64)]
        public string Name { get; set; }
        public List<CityEntity> cityEntity { get; set; }
    }
}
