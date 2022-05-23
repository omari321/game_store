using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameFile.Dtos
{
    public class UploadVideogameFileDto
    {
        public IFormFile formFile { get; set; }
        public int VideogameId { get; set; }
    }
}
