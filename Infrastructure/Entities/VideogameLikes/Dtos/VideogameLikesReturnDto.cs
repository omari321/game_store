using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikes.Dtos
{
    public class VideogameLikesReturnDto
    {
        public int VideogameId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
