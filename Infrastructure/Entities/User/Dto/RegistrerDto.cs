using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User.Dto
{
    public class RegistrerDto
    {
        [Required(ErrorMessage = "User Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]+$",
         ErrorMessage = "Characters are not allowed.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$",
         //ErrorMessage = "Characters are not allowed.")]
        public string? Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        public string? Adress { get; set; }

        public string TelephoneNumber { get; set; }
        public int CityId { get; set; }
    }
}
