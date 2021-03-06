using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public int PublicsherId { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Pick an Image")]
        public IFormFile File { get; set; }
        [Required]
        public string MinRequirements { get; set; }
        [Required]
        public string RecomendedRequirements { get; set; }

    }
}
