using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundQueue.ImageProcessors.Dtos
{
    public class ThumbnailUpdateDto
    {
        public string ThumbnailFilePath { get; set; }
        public int VideogameId { get; set;}
        public string NewPath { get; set; }
    }
}
