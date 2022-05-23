using Infrastructure.Entities.Videogame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Publisher
{
    [Table("Publisher", Schema = "dbo")]
    public class PublisherEntity: BaseEntity
    {
        public int Id { get; set; }
        [StringLength(64)]
        [Unicode(true)]
        public string PublisherName { get; set; }
        public List<VideogameEntity> videoGameEntities { get; set; }
    }
}
