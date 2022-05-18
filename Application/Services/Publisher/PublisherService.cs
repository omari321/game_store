using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Publisher
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepository publisherRepository,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task AddPublisher(AddPublisherDto model)
        {
            var exists = await _publisherRepository.CheckIfAnyByConditionAsync(x => x.PublisherName == model.PublisherName);
            if (exists)
            {
                throw new CustomException("this publiser already exists", 400);
            }
            var newPublisher = new PublisherEntity
            {
                PublisherName=model.PublisherName,
                DateCreated=DateTime.Now,
            };
            await _publisherRepository.CreateAsync(newPublisher);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PageReturnDto<PagingGameDto>> GetGamesByPublisher(QueryParams model,int publisherId)
        {
            var publisher = await _publisherRepository.FindByConditionAsync(x => x.Id == publisherId);
            if (publisher==null)
            {
                throw new CustomException("this publiser does not  exist", 400);
            }
            var item = await _publisherRepository.GetGamesByPublisherAsync(model,x => x.Id== publisher.Id);
            //var Dto = new GetGamesByPublisherDto
            //{
            //    PublisherName = publisherName,
            //    GameList = _mapper.Map<List<ReturnGameDto>>(item.videoGameEntities),
            //};
            //return Dto;
            return item;
        }

        public async Task<IEnumerable<GetPublisherDto>> GetPublishers()
        {
            var publishers=await _publisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetPublisherDto>>(publishers);
        }
    }
}
