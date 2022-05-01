using API.Attributes;
using API.Middlewares;
using Application.Services.Admin;
using Infrastructure.Entities.User.Dto;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles.Admin)]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _AdminService;
        public AdminController(IAdminService AdminService)
        {
            _AdminService = AdminService;
        }
        [HttpPost("[action]")]
       
        public async Task<IActionResult> ChangeUserRole(RoleChangeDto model)
        {
            return Ok(await _AdminService.ChangeUserRole(model));
        }

    }
}
