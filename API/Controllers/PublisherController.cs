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
        [HttpGet("[action]/{publisherName}")]
        public async Task<IActionResult> GetGameByPublisher([FromQuery] QueryParams model, string publisherName)
        {
            Response.Headers.Add("Category", JsonConvert.SerializeObject(publisherName));
            return Ok(await _publisherService.GetGamesByPublisher(model, publisherName));
        }
        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddPublisher(AddPublisherDto model)
        {
            await _publisherService.AddPublisher(model);
            return Ok(new { status = "Publisher Added Succesfully" });
        }
    }
}
