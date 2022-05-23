using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameImages.Dtos
{
    public class AddImagesDto
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public IEnumerable<IFormFile> FormFiles { get; set; }
    }
}
