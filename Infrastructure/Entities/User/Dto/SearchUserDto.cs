using Infrastructure.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.User.Dto
{
    public class SearchUserDto:QueryParams
    {
        public string UserName { get; set; } = "";
    }
}
