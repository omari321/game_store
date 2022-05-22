using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class LoadGameDto
    {
        public int Id { get; set; }
        public string VideogameName { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int PublicsherId { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
    }
}
