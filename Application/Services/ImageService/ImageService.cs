using Application.BackgroundQueue.ImageProcessors.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IVideogameRepository _videogameRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IVideogameRepository videogameRepository,IUnitOfWork unitOfWork)
        {
            _videogameRepository = videogameRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ResizeThumbnail(ThumbnailUpdateDto model,CancellationToken token,int width=400,int height=400)
        {

            Resize(model.ThumbnailFilePath, width, height,model.NewPath);

            var Videogame = await _videogameRepository.FindByConditionAsync(x => x.Id == model.VideogameId);
            Videogame.ThumbnailPath = model.NewPath;
            Videogame.ThumbnailUrl = model.NewThumbnailUrl;
            await _unitOfWork.CompleteAsync();
            File.Delete(model.ThumbnailFilePath);
           
            return true;
        }
        private static void Resize(string srcPath, int width, int height,string savePath)
        {
            Image image = Image.FromFile(srcPath);
            // if you want to Preserve aspect ratio ,then fourth parameter must be true
            Bitmap resultImage = ResizeImage(image, width, height, true);
            resultImage.Save(savePath, ImageFormat.Png);
            resultImage.Dispose();
            image.Dispose();
        }

        /* Resize image and if width and height are different ratio, keep it in center.*/
        private static Bitmap ResizeImage(Image image, int width, int height, bool preserveAspectRatio)
        {
            int drawWidth = width;
            int drawHeight = height;

            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)width / (float)originalWidth;
                float percentHeight = (float)height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                drawWidth = (int)(originalWidth * percent);
                drawHeight = (int)(originalHeight * percent);
            }
            else
            {
                drawWidth = width;
                drawHeight = height;
            }

            var ResizeImage = new Rectangle((width - drawWidth) / 2, (height - drawHeight) / 2, drawWidth, drawHeight);
            var dest_Image = new Bitmap(width, height);

            dest_Image.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(dest_Image))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, ResizeImage, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return dest_Image;
        }
    }
}
