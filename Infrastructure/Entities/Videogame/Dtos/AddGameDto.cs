using Infrastructure.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class AddGameDto
    {
        [Required]
        public string VideogameName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double? OldPrice { get; set; }
        [Required]
        public int PublicsherId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public PlatformEntity PlatformId { get; set; }
        [Required]
        public IFormFile file { get; set; }
    }
}
