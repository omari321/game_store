using API.Context;
using Application.Services.JwtUtils;
using Infrastructure.RepositoryRelated.IRepositories;

namespace API.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware( RequestDelegate next)
        {

            _next = next;
        }
        public async Task Invoke(HttpContext context, IUserRepository userRepository, IJwtUtilsService jwtUtils, UserContext userContext)
        {

            //var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            //var userId = jwtUtils.ValidateJwtToken(token);
            if (userContext.userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await userRepository.FindByConditionAsync(x=>x.Id== userContext.userId);
            }
            await _next(context);
        }
    }
}
