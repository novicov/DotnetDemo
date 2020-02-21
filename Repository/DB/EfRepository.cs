using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.DB
{
    /// <typeparam name="T">Тип сущности</typeparam>
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        public DatabaseContext DbContext;

        protected EfRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }


        public virtual async Task<bool> AnyAsync()
        {
            return await DbContext.Set<T>().AnyAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await DbContext.Set<T>().AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }


        public IQueryable<T> Queryable()
        {
            return DbContext.Set<T>().AsQueryable();
        }
    }
}