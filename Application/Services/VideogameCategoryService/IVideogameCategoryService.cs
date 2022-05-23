using Infrastructure.Entities.VideogameCategories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameCategoryService
{
    public interface IVideogameCategoryService
    {
        Task AddGameCategory(CreateRemoveDto model);
        Task RemoveGameCategory(CreateRemoveDto model);
    }
}
