using Infrastructure.Entities.Publisher;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame
{
    public class VideogameEntity:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [Unicode(true)]
        [StringLength(128)]
        public string VideogameName { get; set; }
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        [Required]
        public int PublicsherId { get; set; }
        public PublisherEntity Publicsher { get; set; }
        [Required]
        [Unicode(true)]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public PlatformEntity PlatformId { get; set; }
        [MaxLength(100)]
        public string? ImageUrl { get; set; }
        //public List<GamesCategoriesEntity> gamesCategoriesEntities { get; set; }
        //public List<CommentsEntity> commentsEntity { get; set; }
        //public List<GameLikesEntity> gameLikesEntity { get; set; }
    }
}
