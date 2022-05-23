using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.VideogameLikesList.Dtos
{
    public class UserGameIsLikedDto
    {
        public int VideogameId { get; set; }
        public string VideogameName { get; set; }
        public bool IsLiked { get; set; }
    }
}
