using API.Controllers;

namespace API.Extensions
{
    public  static class AuthControllerExtension
    {
        public static void SetTokenCookie(this AuthController authenticateController, string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            authenticateController.Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
