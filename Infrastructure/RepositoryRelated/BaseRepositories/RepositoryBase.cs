using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected EntityDbContext _entityDbContext;
        public RepositoryBase(EntityDbContext entityDbContext)
        {
            _entityDbContext = entityDbContext;
        }

        public async Task<bool> CheckIfMeetsAnyConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _entityDbContext.Set<T>().AnyAsync(expression);
        }

        public async Task CreateAsync(T entity)
        {
            await _entityDbContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _entityDbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
        public async Task Delete(T entity) => _entityDbContext.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entityDbContext.Set<T>().ToListAsync();
        }

        public  IQueryable<T> GetAllQuery()
        {
            return _entityDbContext.Set<T>().AsQueryable();
        }
    }
}
