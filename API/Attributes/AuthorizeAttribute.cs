using Infrastructure.Entities.User;
using Infrastructure.Entities.UserRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Roles> _roles;

        public AuthorizeAttribute(params Roles[] roles)
        {
            _roles = roles ?? new Roles[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymus = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymus)
                return;
            foreach (var key in context.HttpContext.Items.Keys)
            {
                var item = context.HttpContext.Items[key];
            }
            var user = (UserEntity)context.HttpContext.Items["User"];
            
            if (user == null || (_roles.Any() && !_roles.Contains(user.Role)))
            {

                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            }
        }
    }
}
