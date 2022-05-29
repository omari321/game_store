using Application;
using Application.BackgroundQueue;
using Application.BackgroundQueue.ImageProcessors.Dtos;
using Application.Services.Videogame;
using AutoMapper;
using Infrastructure.Entities.Videogame;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Shared;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var basePath = new BasePath("rame");
            var baseUrl = new BaseUrl
            {
                applicationUrl="url"
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var videogameRepository = new Mock<IVideogameRepository>();

            var myProfile = new AutoMapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m.Map<Foo, Bar>(It.IsAny<Foo>())).Returns(new Bar());
            IBackgroundQueue<ThumbnailUpdateDto> backgroundQueue = new BackgroundQueue<ThumbnailUpdateDto>();
            var ownedgamesRepository = new Mock<IOwnedGamesRepository>();
            var videogameFileRepository=new Mock<IVideogameFileRepository>();
            var videogameRequirementsRepository=new Mock<IVideogameRequirementsRepository>();
            var videogameLikesRepository = new Mock<IVideogameLikesRepository>();

            var bytes = Encoding.UTF8.GetBytes("This is a dummy file");
            IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.png");
            var updateGameDto = new UpdateGameDto
            {
                VideoGameName="raime",
                Price=10.1,
                Description="good game",
            };

            videogameRepository.Setup(x => x.FindByConditionAsync(It.IsAny<Expression<Func<VideogameEntity, bool>>>()))
                .Returns
                (Task.FromResult(new VideogameEntity
                {
                    Id =1,
                    VideogameName = "raime",
                    Price = 1,
                    OldPrice =0 ,
                    PublicsherId =1,
                    Description = "good game",
                })
                );
            unitOfWork.Setup(x => x.CompleteAsync()).Returns(Task.CompletedTask);
            var videogameService = new VideogameService(basePath,baseUrl,unitOfWork.Object,videogameRepository.Object, mapper,backgroundQueue,ownedgamesRepository.Object, videogameFileRepository.Object, videogameRequirementsRepository.Object, videogameLikesRepository.Object);
            var result = videogameService.UpdateGame(updateGameDto).GetAwaiter().GetResult();
            Assert.NotNull(result);
        }
    }
}