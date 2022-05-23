using Infrastructure.Entities.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryRelated.IRepositories
{
    public interface ICountryRepository:IRepositoryBase<CountryEntity>
    {
    }
}
