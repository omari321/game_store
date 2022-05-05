using Application.Exceptions;
using Infrastructure.Entities.VideogameCategories;
using Infrastructure.Entities.VideogameCategories.Dto;
using Infrastructure.RepositoryRelated.IRepositories;
using Infrastructure.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VideogameCategoryService
{
    public class VideogameCategoryService : IVideogameCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVideogameCategoryRepository _videogameCategoryRepository;
        public VideogameCategoryService(IUnitOfWork unitOfWork, IVideogameCategoryRepository videogameCategoryRepository)
        {
            _videogameCategoryRepository = videogameCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddGameCategory(CreateRemoveDto model)
        {
            var exists = await CheckIfExist(model);
            if (exists)
            {
                throw new CustomException("this kind of relation already exists",400);
            }
            var GameCategory = new VideogameCategoryEntity
            {
                VideogameId = model.VideogameId,
                CategoryId = model.CategoryId,
                DateCreated = DateTime.Now,
            };
            await _videogameCategoryRepository.CreateAsync(GameCategory);
            await _unitOfWork.CompleteAsync();
        }
        private async Task<bool> CheckIfExist(CreateRemoveDto model)
        {
            return await _videogameCategoryRepository.CheckIfAnyByConditionAsync(x=>x.VideogameId==model.VideogameId && x.CategoryId==model.CategoryId);
        }
        private async Task<VideogameCategoryEntity> GetByIds(CreateRemoveDto model)
        {
            return await _videogameCategoryRepository.FindByConditionAsync(x => x.VideogameId == model.VideogameId && x.CategoryId == model.CategoryId);
        }
        public async Task RemoveGameCategory(CreateRemoveDto model)
        {
            var Relation = await GetByIds(model);
            if (Relation == null)
            {
                throw new CustomException("this kind of relation does not exist", 400);
            }
            await _videogameCategoryRepository.Delete(Relation);
            await _unitOfWork.CompleteAsync();
        }
    }
}
