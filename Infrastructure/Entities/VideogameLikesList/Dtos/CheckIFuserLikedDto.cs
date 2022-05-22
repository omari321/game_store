using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikesList.Dtos
{
    public class CheckIFuserLikedDto
    {
        public bool IsLike { get; set; }
        public int VideogameId { get; set; }
        public int UserId { get; set; }
    }
}
