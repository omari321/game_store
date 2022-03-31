using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        void Save();
    }
}
