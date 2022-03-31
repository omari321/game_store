using Infrastructure.Entities.VideoGame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Developer
{
    [Table("Developer",Schema ="dbo")]
    public class DeveloperEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        [Unicode(true)]
        public string PublisherName { get; set; }
        public List<VideoGameEntity> videoGameEntities { get; set; }
    }
}
