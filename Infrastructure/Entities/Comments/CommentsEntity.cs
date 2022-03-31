using Infrastructure.Entities.CommentLikes;
using Infrastructure.Entities.User;
using Infrastructure.Entities.VideoGame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Comments
{
    [Table("Comments",Schema ="dbo")]
    public class CommentsEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VideoGameId { get; set; }
        public VideoGameEntity VideoGame { get; set; }

        [Required]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        [Unicode(true)]
        [MaxLength]
        public string Comment { get; set; }
        [NotMapped]
        public List<CommentLikesEntity> CommentLikesEntity { get; set; }
    }
}
