using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameImages.Dtos
{
    public class RemoveImageDto
    {
        [Required]
        public int  imageId{ get; set; }
    }
}
