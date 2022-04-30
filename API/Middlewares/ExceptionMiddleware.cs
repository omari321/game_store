using Application.Exceptions;
using Shared;
using System.Net;

namespace API.Middlewares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                switch (ex)
                {
                    case CustomException:
                        context.Response.StatusCode = ((CustomException)ex).StatusCode;
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                await context.Response.WriteAsync(new ErrorDetail
                {
                    StatusCode = context.Response.StatusCode,
                    Message = ex?.Message,
                }.ToString());
            }

        }
    }
}
