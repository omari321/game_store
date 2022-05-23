using Infrastructure.Entities.VideogameImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameImagesRepository:IRepositoryBase<VideogameImagesEntity>
    {
        Task<IEnumerable<VideogameImagesEntity>> GetVideogameImages(int videogameId); 
    }
}
