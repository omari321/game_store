using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.City;
using Infrastructure.Entities.City.Dtos;
using Infrastructure.Entities.Country;
using Infrastructure.Entities.Country.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CityCountry
{
    public class CityCountryService : ICityCountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CityCountryService(ICityRepository cityRepository,
            ICountryRepository countryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public async Task<GetCountryDto> AddCountry(AddCountryDto model)
        {
            var exists = await _countryRepository.CheckIfAnyByConditionAsync(x => x.Name == model.CountryName);
            if (exists)
            {
                throw new CustomException("this country already exists", 400);
            }
            var newCountry = new CountryEntity
            {
                Name = model.CountryName,
                DateCreated=DateTime.Now,
            };
            await _countryRepository.CreateAsync(newCountry);
            await _unitOfWork.CompleteAsync();
            return new GetCountryDto
            {
                Id=newCountry.Id,
                CountryName = newCountry.Name
            };
        }
        public async Task<GetCityDto> AddCity(AddCityDto model)
        {
            var exists = await _cityRepository.CheckIfAnyByConditionAsync(x => x.Name == model.CityName);
            if (exists)
            {
                throw new CustomException("this city already exists", 400);
            }
            var country = await _countryRepository.FindByConditionAsync(x => x.Name == model.CityCountryName);
            if (country==null)
            {
                throw new CustomException("country with this name does not exist", 400);
            }
            var newCity = new CityEntity
            {
                Name = model.CityName,
                CountryId= country.Id,
                DateCreated = DateTime.Now,
            };
            await _cityRepository.CreateAsync(newCity);
            await _unitOfWork.CompleteAsync();
            return new GetCityDto
            {
                Id=newCity.Id,
                Name = newCity.Name,
                CountryId=newCity.CountryId
            };
        }

        public async Task<IEnumerable<GetCityDto>> GetAllCities()
        {
            var items=await _cityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCityDto>>(items);
        }

        public async Task<IEnumerable<GetCountryDto>> GetAllCountries()
        {
            var items = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetCountryDto>>(items);
        }
    }
}
