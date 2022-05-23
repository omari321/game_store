using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameRequirements
{
    [Table("VideogameRequirements", Schema = "dbo")]
    public class VideogameRequirementsEntity : BaseEntity
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public VideogameEntity Videogame { get; set; }
        public string MinRequirements { get; set; }
        public string RecomendedRequirements { get; set; }
    }
}
