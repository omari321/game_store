using Infrastructure.Entities.Videogame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Categories.Dtos
{
    public class GamesByCategoryDto
    {
        public int CategoryId { get; set; }
        public IEnumerable<ReturnGameDto> Games { get; set; }
    }
}
