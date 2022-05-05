using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame
{
    [Table("Videogame", Schema = "dbo")]
    public class VideogameEntity:BaseEntity
    {
        public int Id { get; set; }
        [Unicode(true)]
        [StringLength(128)]
        public string VideogameName { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int PublicsherId { get; set; }
        public PublisherEntity Publicsher { get; set; }
        [Unicode(true)]
        [MaxLength(2000)]
        public string Description { get; set; }
        public PlatformEntity PlatformId { get; set; }
        [MaxLength(100)]
        public string? ImageUrl { get; set; }
        public List<VideogameCategoryEntity> videogameCategoryEntities{ get; set; }
        //public List<CommentsEntity> commentsEntity { get; set; }
        //public List<GameLikesEntity> gameLikesEntity { get; set; }
    }
}
