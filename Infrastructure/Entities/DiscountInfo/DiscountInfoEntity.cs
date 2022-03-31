using Infrastructure.Entities.VideoGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.DiscountInfo
{
    [Table("DiscountInfo",Schema ="dbo")]
    public class DiscountInfoEntity:BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        [MaxLength(128)]
        //not required
        public string DiscountInfo { get; set; }
        [Required]
        public double PaymentPercentage { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; }
        public List<VideoGameEntity> videoGameEntities { get; set; }
    }
}
