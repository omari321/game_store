using Application.BackgroundQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.ImageService;
using Application.BackgroundQueue.ImageProcessors.Dtos;

namespace Application.Extensions
{
    public static class BackgroundServiceAppServiceExtension
    {
        public static void BackgroundServiceAppServiceExtensionMethod(this IServiceCollection services)
        {
            services
            .AddHostedService<ThumbnailBackgroundWorker>()
            .AddSingleton<IBackgroundQueue<ThumbnailUpdateDto>, BackgroundQueue<ThumbnailUpdateDto>>();

           services.AddScoped<IImageService, ImageService>();
        }

    }
}
