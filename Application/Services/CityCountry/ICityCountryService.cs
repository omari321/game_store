using Infrastructure.Entities.City.Dtos;
using Infrastructure.Entities.Country.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CityCountry
{
    public interface ICityCountryService
    {
        Task<GetCityDto> AddCity(AddCityDto model);
        Task<GetCountryDto> AddCountry(AddCountryDto model);
        Task<IEnumerable<GetCountryDto>> GetAllCountries();
        Task<IEnumerable<GetCityDto>> GetAllCities();          
    }
}
