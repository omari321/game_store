using Application.Services.JwtUtils;

namespace API.Context
{
    public class UserContextFactory
    {
        public static UserContext Create(IServiceProvider ctx)
        {
            var httpContext = ctx.GetService<IHttpContextAccessor>()?.HttpContext;
            var jwtutils = ctx.GetService<IJwtUtilsService>();
            return Create(httpContext, jwtutils);
        }

        public static UserContext Create(HttpContext httpContext, IJwtUtilsService jwtUtils)
        {
            var remoteIpAddress = httpContext?.Connection?.RemoteIpAddress?.ToString();

            var header = httpContext?.Request.Headers["Authorization"];
            var auth = header?.FirstOrDefault()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var token = auth?.LastOrDefault();

            if (httpContext != null && !string.IsNullOrEmpty(token))
            {
                var userToken = httpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateJwtToken(token);
                return new UserContext(userId, remoteIpAddress);
            }


            return new UserContext(remoteIpAddress);
        }
    }
}
