using Infrastructure.Entities.Videogame;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameImages
{
    [Table("VideogameImages", Schema = "dbo")]
    [Index(nameof(VideogameId))]
    public class VideogameImagesEntity:BaseEntity
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public VideogameEntity Videogame { get; set; }
        public string ImageUrl { get; set; }
    }
}
