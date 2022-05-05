using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class UpdateGameDto
    {
        [Required]
        public string? VideoGameName { get; set; }
        [Required]
        public double? Price { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Pick an Image")]
        public IFormFile File { get; set; }
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public string FileName => File?.FileName;
        [Required]
        public string? Description { get; set; }
    }
}
