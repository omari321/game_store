using Infrastructure.Entities.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class GameInformationForAdminDto
    {
        public int VideogameId { get; set; }
        public string VideogameName { get; set; }
        public double Price { get; set; }
        public List<GetCategoriesDto> VideogamesCategories { get; set; } = new();

    }
}
