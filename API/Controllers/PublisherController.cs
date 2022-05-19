using API.Attributes;
using API.Middlewares;
using Application.Services.Publisher;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.UserRepo;
using Infrastructure.Paging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles.Admin, Roles.Manager)]
    public class PublisherController:ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPublisers()
        {
            return Ok(await _publisherService.GetPublishers());
        }
        [AllowAnonymous]
        [HttpGet("[action]/{publisherId}")]
        public async Task<IActionResult> GetGameByPublisher([FromQuery] QueryParams model, int publisherId)
        {
            return Ok(await _publisherService.GetGamesByPublisher(model, publisherId));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddPublisher(AddPublisherDto model)
        {
            return Ok(await _publisherService.AddPublisher(model));
        }
    }
}
