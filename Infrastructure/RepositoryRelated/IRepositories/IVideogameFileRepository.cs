using Infrastructure.Entities.VideogameFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface IVideogameFileRepository:IRepositoryBase<VideogameFilesEntity>
    {
        Task<VideogameFilesEntity> GetLatestVersion(int videoGameId);
    }
}
