using Infrastructure.Entities.Videogame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Publisher.Dto
{
    public class GetGamesByPublisherDto
    {
       // public string PublisherName { get; set; }
        public IEnumerable<ReturnGameDto> GameList { get; set; }
    }
}
