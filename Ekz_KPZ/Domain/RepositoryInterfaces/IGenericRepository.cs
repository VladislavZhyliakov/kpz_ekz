using System.Linq.Expressions;

namespace Domain.RepositoryInterfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
