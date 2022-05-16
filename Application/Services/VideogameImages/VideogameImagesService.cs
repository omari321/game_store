using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.VideogameImages;
using Infrastructure.Entities.VideogameImages.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameImages
{
    public class VideogameImagesService : IVideogameImagesService
    {
        private readonly IVideogameImagesRepository _videogameImagesRepository;
        private readonly IVideogameRepository _videogameRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BasePath _basePath;
        private const string BaseImagePath = @"Images\Games";
        private readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
        private readonly IMapper _mapper;
        public VideogameImagesService(BasePath basePath,IVideogameImagesRepository videogameImagesRepository, IVideogameRepository videogameRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _videogameImagesRepository = videogameImagesRepository;
            _videogameRepository = videogameRepository;
            _unitOfWork = unitOfWork;
            _basePath = basePath;
            _mapper = mapper;
        }

        public async Task<bool> AddImagesToGame(AddImagesDto model)
        {
            var exists = await _videogameRepository.CheckIfAnyByConditionAsync(x => x.Id == model.GameId);
            if (exists is  false)
            {
                throw  new CustomException("this game id does not exist",404);
            }
            foreach(var item in model.FormFiles)
            {
                if (!ImageExtensions.Contains(Path.GetExtension(item.FileName).ToUpper()))
                {
                    throw new CustomException("unsaported image type", 400);
                }
                if (item.Length> 8_200_000)
                {
                    throw new CustomException("One of the images size is too big(larger than 8 mb)", 400);
                }
                var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
                var FullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, FileName + Path.GetExtension(item.FileName));
                await using (var fileStreams = new FileStream(FullPath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStreams);
                }
                var newImage = new VideogameImagesEntity
                {
                    VideogameId = model.GameId,
                    ImageUrl = FullPath,

                    DateCreated = DateTime.Now,
                };
                await _videogameImagesRepository.CreateAsync(newImage);
            }
            await _unitOfWork.CompleteAsync();       
            return true;
        }

        public async Task<bool> RemoveImage(RemoveImageDto model)
        {
            var image = await _videogameImagesRepository.FindByConditionAsync(x => x.Id == model.imageId);
            if (image == null)
            {
                throw new CustomException("image with this id does not exist ", 400);
            }
            await _videogameImagesRepository.Delete(image);
            File.Delete(image.ImageUrl);
            return true;
        }

        public async Task<IEnumerable<GetImagesDto>> GetVideogameImages(int videogameId)
        {
            var exists = await _videogameRepository.CheckIfAnyByConditionAsync(x => x.Id == videogameId);
            if (!exists)
            {
                throw new CustomException("this game id does not exist", 404);
            }
            var items = await _videogameImagesRepository.GetVideogameImages(videogameId);
            return _mapper.Map<IEnumerable<GetImagesDto>>(items);
        }
    }
}
