using Application.Exceptions;
using AutoMapper;
using Infrastructure.Entities.Categories;
using Infrastructure.Entities.Categories.Dtos;
using Infrastructure.Entities.Videogame.Dtos;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideogameCategoryRepository _videogameCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IVideogameCategoryRepository videogameCategoryRepository, ICategoryRepository categoryRepository,IMapper mapper )
        {
            _videogameCategoryRepository = videogameCategoryRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        private async Task<bool> CheckIfExists(string name)
        {
            return await _categoryRepository.CheckIfAnyByConditionAsync(x => x.CategoryName == name);
        }
        public async Task AddCategory(CreateCategoryDto model)
        {
            var exists=await CheckIfExists(model.CategoryName);
            if (exists)
            {
                throw new CustomException("this category already exists", 400);
            }
            var Category = new CategoryEntity
            {
                CategoryName=model.CategoryName,
                DateCreated=DateTime.Now,
            };
            await _categoryRepository.CreateAsync(Category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<List<GetCategoriesDto>> GetCategories()
        {
            var items = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<GetCategoriesDto>>(items);
        }

        public async Task<GamesByCategoryDto> GetGamesByCategory(int categoryId)
        {
            var CategoryGames = await _videogameCategoryRepository.GetGamesByCategory(x => x.CategoryId == categoryId);
            if (CategoryGames==null)
            {
                throw new CustomException("this category id does not exist", 400);
            }
            var ReturnData = new GamesByCategoryDto
            {
                CategoryId = categoryId,
                Games = CategoryGames.Select(x =>
                {
                    return _mapper.Map<ReturnGameDto>(x.Game);
                }),
                
            };
            return ReturnData;
        }

        public async Task<CategoriesByGame> GetCategoriesByGame(int gameId)
        {
            var GameCategories = await _videogameCategoryRepository.GetCategoriesByGame(x => x.VideogameId == gameId);
            if (GameCategories == null)
            {
                throw new CustomException("this game id does not exist", 400);
            }
            var ReturnData = new CategoriesByGame
            {
                GameId = gameId,
                Categories = GameCategories.Select(x =>
                {
                    return _mapper.Map<GetCategoriesDto>(x.Category);
                }),
            };
            return ReturnData;
        }
    }
}
