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
        private readonly BaseUrl _baseUrl;
        private const string BaseImagePath = @"wwwroot/Images/Games";
        private const string BaseImageUrl = @"/Images/Games/";
        private readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
        private readonly IMapper _mapper;
        public VideogameImagesService(BasePath basePath,BaseUrl baseUrl,IVideogameImagesRepository videogameImagesRepository, IVideogameRepository videogameRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _videogameImagesRepository = videogameImagesRepository;
            _videogameRepository = videogameRepository;
            _unitOfWork = unitOfWork;
            _basePath = basePath;
            _baseUrl = baseUrl;
            _mapper = mapper;
        }

        public async Task<List<GetImagesDto>> AddImagesToGame(AddImagesDto model)
        {
            var exists = await _videogameRepository.CheckIfMeetsAnyConditionAsync(x => x.Id == model.GameId);
            if (exists is  false)
            {
                throw  new CustomException("this game id does not exist",404);
            }
            var ReturnDto = new List<GetImagesDto>();
            var index = 0;
            foreach (var item in model.FormFiles)
            {
                index += 1;
                if (!ImageExtensions.Contains(Path.GetExtension(item.FileName).ToUpper()))
                {
                    throw new CustomException($"unsaported image type for image number {index} with name {item.FileName} quitting upload", 400);
                }
                if (item.Length> 8_200_000)
                {
                    throw new CustomException($"Images with index {index} ,name {item.FileName}, size is too big(larger than 8 mb) quitting upload", 400);
                }
                var FileName = Path.GetRandomFileName().Split(".").ToArray()[0];
                var FullPath = Path.Combine(_basePath.ContentRootPath, BaseImagePath, FileName + Path.GetExtension(item.FileName));
                var ImageUrl= _baseUrl.applicationUrl + BaseImageUrl + FileName + Path.GetExtension(item.FileName);
                await using (var fileStreams = new FileStream(FullPath, FileMode.Create))
                {
                    await item.CopyToAsync(fileStreams);
                }
                var newImage = new VideogameImagesEntity
                {
                    VideogameId = model.GameId,
                    ImagePath = FullPath,
                    ImageUrl = ImageUrl,
                    DateCreated = DateTime.Now,
                };

                await _videogameImagesRepository.CreateAsync(newImage);         
                await _unitOfWork.CompleteAsync();  
                var imageDto = new GetImagesDto
                {
                    Id=newImage.Id,
                    VideogameId=newImage.VideogameId,
                    ImageUrl=newImage.ImageUrl,
                };
                ReturnDto.Add(imageDto);
            }
                 
            return ReturnDto;
        }

        public async Task<bool> RemoveImage(RemoveImageDto model)
        {
            var image = await _videogameImagesRepository.FindByConditionAsync(x => x.Id == model.imageId);
            if (image == null)
            {
                throw new CustomException("image with this id does not exist ", 400);
            }
            await _videogameImagesRepository.Delete(image);
            File.Delete(image.ImagePath);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<GetImagesDto>> GetVideogameImages(int videogameId)
        {
            var exists = await _videogameRepository.CheckIfMeetsAnyConditionAsync(x => x.Id == videogameId);
            if (!exists)
            {
                throw new CustomException("this game id does not exist", 404);
            }
            var items = await _videogameImagesRepository.GetVideogameImages(videogameId);
            return _mapper.Map<IEnumerable<GetImagesDto>>(items);
        }
    }
}
