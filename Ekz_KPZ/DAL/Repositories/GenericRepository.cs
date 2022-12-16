using System.Linq.Expressions;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected ApplicationContext _appContext;
        
        public GenericRepository(ApplicationContext context) => _appContext = context;

        public async Task<int> CreateAsync(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync();
            return entity.Id; 
        }

        public async Task DeleteAsync(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await _appContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _appContext.Set<T>().AsQueryable().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return await _appContext.Set<T>().Where(condition).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await _appContext.SaveChangesAsync();
        }
    }
}
