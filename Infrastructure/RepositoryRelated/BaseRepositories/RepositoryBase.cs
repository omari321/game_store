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
        public async Task CreateAsync(T entity)=>
            await _entityDbContext.Set<T>().AddAsync(entity);

        public async Task Delete(T entity) => await Task.Run(() =>
        _entityDbContext.Set<T>().Remove(entity));

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression) => 
            await _entityDbContext.Set<T>().FindAsync(expression);

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges) =>
            await _entityDbContext.Set<T>().ToListAsync();

        public void Save() =>_entityDbContext.SaveChanges();

        public async Task Update(T entity)=>
            await Task.Run(()=> _entityDbContext.Set<T>().Update(entity));
    }
}
