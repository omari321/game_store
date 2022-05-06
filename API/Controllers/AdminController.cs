using API.Attributes;
using API.Middlewares;
using Application.Services.Admin;
using Application.Services.Category;
using Application.Services.CityCountry;
using Application.Services.Publisher;
using Application.Services.Videogame;
using Application.Services.VideogameCategoryService;
using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.City.Dtos;
using Infrastructure.Entities.Country.Dtos;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Entities.VideogameCategories.Dto;
using Infrastructure.Paging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles.Admin)]
    
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _AdminService;
        private readonly ICityCountryService _cityCountryService;
        public AdminController(IAdminService AdminService, ICityCountryService cityCountryService)
        {
            _AdminService = AdminService;
            _cityCountryService = cityCountryService;
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ChangeUserRole(RoleChangeDto model)
        {
            return Ok(await _AdminService.ChangeUserRole(model));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCountry(AddCountryDto model)
        {
            await _cityCountryService.AddCountry(model);
            return Ok(new {status="Country Added Succesfully"});
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddCity(AddCityDto model)
        {
            await _cityCountryService.AddCity(model);
            return Ok(new { status = "City Added Succesfully" });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCities()
        {          
            return Ok(await _cityCountryService.GetAllCities());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await _cityCountryService.GetAllCountries());
        }


    }
}
