using Infrastructure.Entities.User;
using Infrastructure.Entities.Videogame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikesList
{
    [Table("VideogameLikesList", Schema = "dbo")]
    [Index(nameof(VideogameId))]
    public class VideogameLikesListEntity:BaseEntity
    {
        public int Id { get; set; }
        public bool IsLike { get; set; }
        public int VideogameId { get; set; }
        public VideogameEntity Videogame { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
