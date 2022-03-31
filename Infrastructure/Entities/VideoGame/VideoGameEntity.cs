using Infrastructure.Entities.Comments;
using Infrastructure.Entities.Developer;
using Infrastructure.Entities.DiscountInfo;
using Infrastructure.Entities.GamesCategories;
using Infrastructure.Entities.GameVisits;
using Infrastructure.Entities.PhysicalGamesKey;
using Infrastructure.Entities.Publisher;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities.VideoGame
{
    [Table("VideoGame", Schema = "dbo")]
    public class VideoGameEntity:BaseEntity
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        [Unicode(true)]
        [StringLength(128)]
        public string VideoGameName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int PublicsherId { get; set; }
        public PublisherEntity Publicsher { get; set; }
        [Required]
        public int AvailQuantity { get; set; }
        [Required]
        public int DeveloperId { get; set; }
        public DeveloperEntity Developer { get; set; }
        [Required]
        [Unicode(true)]
        [MaxLength]
        public string Description { get; set; }
        [Required]
        public PlatformEntity PlatformId { get; set; }
        [Required]
        public int DiscountId { get; set; }
        public DiscountInfoEntity Discount { get; set; }
        public List<PhysicalGamesKeysEntitys> physicalGamesKeysEntitys { get; set; }
        public List<GamesCategoriesEntity> gamesCategoriesEntities { get; set; }
        public List<CommentsEntity> commentsEntity { get; set; }
    }
}
