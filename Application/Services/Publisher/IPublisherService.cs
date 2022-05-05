using Infrastructure.Entities.Publisher.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Publisher
{
    public interface IPublisherService
    {
        Task AddPublisher(AddPublisherDto model);
        Task<GetGamesByPublisherDto> GetGamesByPublisher(string publisherName);
        Task<IEnumerable<GetPublisherDto>> GetPublishers();
    }
}
