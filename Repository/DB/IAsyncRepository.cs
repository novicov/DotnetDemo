using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.DB
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<bool> AnyAsync();
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}