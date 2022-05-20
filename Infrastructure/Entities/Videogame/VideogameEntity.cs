using Infrastructure.Entities.OwnedGames;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Transactions;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Entities.VideogameFile;
using Infrastructure.Entities.VideogameImages;
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
        [MaxLength(100)]
        public string? ThumbnailPath { get; set; }
        public string? ThumbnailUrl { get; set;}
        public string? DownloadFileUrl { get; set; }
        public List<VideogameFilesEntity> videogameFilesEntities { get; set; }
        public List<VideogameCategoryEntity> videogameCategoryEntities{ get; set; }
        public List<TransactionsEntity> transactionsEntities { get; set; }
        public List<OwnedGamesEntity> ownedGamesEntities { get; set; }
        public List<VideogameImagesEntity> videogameImagesEntities { get; set; }
        //public List<CommentsEntity> commentsEntity { get; set; }
        //public List<GameLikesEntity> gameLikesEntity { get; set; }
    }
}
