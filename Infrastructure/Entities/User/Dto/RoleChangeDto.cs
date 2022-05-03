using Infrastructure.Entities.UserRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User.Dto
{
    public class RoleChangeDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public Roles newRole { get; set; }

    }
}
