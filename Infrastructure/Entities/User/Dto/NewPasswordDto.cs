using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User.Dto
{
    public class NewPasswordDto
    {
        [Required]
        public string oldPassword { get; set; }
        [Required]
        public string newPassword { get; set; }
    }
}
