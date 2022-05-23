using Infrastructure.Entities.Country;
using Infrastructure.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.City
{
    [Table("City",Schema ="dbo")]
    public class CityEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Unicode(true)]
        [StringLength(65)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }
        public List<UserEntity> userEntities { get; set; }
    }
}
