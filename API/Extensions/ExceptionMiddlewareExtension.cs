using Microsoft.AspNetCore.Diagnostics;
using Shared.ErrorModel;
using System.Net;

namespace API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //adds a middleware to the pipeline
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //creates response 
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetail
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error"
                        }.ToString()); ;
                    }
                });
            });
        }
    }
}
