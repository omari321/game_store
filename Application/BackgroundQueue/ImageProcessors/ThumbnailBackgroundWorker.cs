using Application.BackgroundQueue.ImageProcessors.Dtos;
using Application.Services.ImageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BackgroundQueue
{
    public class ThumbnailBackgroundWorker : BackgroundService
    {
        private readonly IBackgroundQueue<ThumbnailUpdateDto> _queue;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ThumbnailBackgroundWorker> _logger;

        public ThumbnailBackgroundWorker(IBackgroundQueue<ThumbnailUpdateDto> queue, IServiceScopeFactory scopeFactory,
            ILogger<ThumbnailBackgroundWorker> logger)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Type} is now running in the background.", nameof(ThumbnailBackgroundWorker));

            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical(
                "The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.",
                nameof(ThumbnailBackgroundWorker)
            );

            return base.StopAsync(cancellationToken);
        }
        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(500, stoppingToken);
                    var model = _queue.Dequeue();

                    if (model == null) continue;

                    _logger.LogInformation("Book found! Starting to process ..");

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var imageService = scope.ServiceProvider.GetRequiredService<IImageService>();

                        await imageService.ResizeThumbnail(model, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("An error occurred when publishing a book. Exception: {@Exception}", ex);
                }
            }
        }
    }
}
