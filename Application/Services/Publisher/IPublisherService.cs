using Infrastructure.Entities.Publisher.Dto;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.Paging;
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
        Task<PageReturnDto<ReturnGameDto>> GetGamesByPublisher(QueryParams model,string publisherName);
        Task<IEnumerable<GetPublisherDto>> GetPublishers();
    }
}
