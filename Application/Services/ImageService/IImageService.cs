using Application.BackgroundQueue.ImageProcessors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageService
{
    public interface IImageService
    {
        Task<bool> ResizeThumbnail(ThumbnailUpdateDto model, CancellationToken token, int width=400, int height=400);
    }
}
