using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.PhysicalGamesKey
{
    [Table("PhysicalGamesKeys")]
    public class PhysicalGamesKeysEntitys:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Game { get; set; }
        public VideoGameEntity GameId { get; set; }
        [DefaultValue(false)]
        public bool AlreadyUsed { get; set; }
        [Required]
        [MaxLength(128)]
        public string Key { get; set; }
       
    }
}
