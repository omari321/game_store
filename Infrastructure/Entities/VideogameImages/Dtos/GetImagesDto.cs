using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameImages.Dtos
{
    public class GetImagesDto
    {
        public int Id { get; set; }
        public int VideogameId { get; set; }
        public string ImageUrl { get; set; }
    }
}
