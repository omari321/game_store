using Infrastructure.Entities.Videogame;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameFile
{
    [Table("VideogameFiles", Schema = "dbo")]
    public class VideogameFilesEntity:BaseEntity
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public string FileName { get; set; }
        public VideogameEntity Videogame { get; set; }
        public string VideogameFilePath { get; set; }
        public int Version { get; set; }
    }
}
