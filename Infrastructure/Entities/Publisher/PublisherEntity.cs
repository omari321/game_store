using Infrastructure.Entities.VideoGame;
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
    [Table("Publisher",Schema ="dbo")]
    public class PublisherEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(true)]
        public string DeveloperName { get; set; }
        public List<VideoGameEntity> videoGameEntities { get; set; }
    }
}
