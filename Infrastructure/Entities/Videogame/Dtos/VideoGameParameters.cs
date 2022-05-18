using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class VideoGameParameters:QueryParams
    {
        public uint MinPrice { get; set; } 
        public uint MaxPrice { get; set; } = int.MaxValue;
        public bool ValidPrice => MaxPrice > MinPrice;

        public string SearchTerm { get; set; } = "";
    }
}
