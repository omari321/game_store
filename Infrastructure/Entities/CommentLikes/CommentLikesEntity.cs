using Infrastructure.Entities.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.CommentLikes
{
    [Table("CommentLikes",Schema ="dbo")]
    [Index(nameof(commentId),nameof(PositiveComment))]
    public class CommentLikesEntity:BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [ForeignKey("CommentsEntity")]
        public int commentId { get; set; }
        public CommentsEntity comment { get; set; }
        [Required]
        public bool PositiveComment { get; set; }
        
    }
}
