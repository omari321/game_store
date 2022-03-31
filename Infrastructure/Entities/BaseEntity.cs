using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
