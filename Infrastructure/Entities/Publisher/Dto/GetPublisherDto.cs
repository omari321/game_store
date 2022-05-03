using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Publisher.Dto
{
    public class GetPublisherDto
    {
        public int PublisherId { get; set; } 
        public string PublisherName { get; set; }
    }
}
