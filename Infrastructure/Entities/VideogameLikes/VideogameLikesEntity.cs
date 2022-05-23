using Infrastructure.Entities.User;
using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikes
{
    [Table("VideogameLikes", Schema = "dbo")]

    public  class VideogameLikesEntity:BaseEntity
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public VideogameEntity Videogame { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }

    }
}
