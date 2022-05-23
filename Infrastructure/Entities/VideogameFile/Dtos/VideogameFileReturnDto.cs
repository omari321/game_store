using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameFile.Dtos
{
    public class VideogameFileReturnDto
    {
        public int VideogameId { get; set; }
        public string FileName { get; set; }
        public string VideogameFilePath { get; set; }
        public int Version { get; set; }
    }
}
