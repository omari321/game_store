using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Publisher;
using Infrastructure.Entities.Publisher.Dto;
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
            var exists = await _publisherRepository.CheckIfAnyByConditionAsync(x => x.PublisherName == name);
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

        public async Task<List<GetGamesByPublisherDto>> GetGamesByPublisher(string publisherName)
        {
            var publisher = await _publisherRepository.FindByConditionAsync(x => x.PublisherName == publisherName);
            if (publisher==null)
            {
                throw new CustomException("this publiser does not  exist", 400);
            }
            var item = await _publisherRepository.GetGamesByPublisherAsync(x => x.Id== publisher.Id);
            return _mapper.Map<List<GetGamesByPublisherDto>>(item);
        }

        public async Task<IEnumerable<GetPublisherDto>> GetPublishers()
        {
            var publishers=await _publisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetPublisherDto>>(publishers);
        }
    }
}
