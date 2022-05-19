using Infrastructure.Entities.VideogameImages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameImages
{
    public interface IVideogameImagesService
    {
        Task<List<GetImagesDto>> AddImagesToGame(AddImagesDto model);
        Task<bool> RemoveImage(RemoveImageDto model);
        Task<IEnumerable<GetImagesDto>> GetVideogameImages(int VideogameId);
    }
}
