using Microsoft.EntityFrameworkCore;
using VirtualAcademy.Application.Contracts.Persistence;
using VirtualAcademy.Domain.Common;

namespace VirtualAcademy.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetByIdAsync(Guid id)
            => await _dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllByIdsAsync(IEnumerable<Guid> ids)
            => await _dbContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();

        public async Task AddAsync(T entity)
            => await _dbContext.Set<T>().AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbContext.Set<T>().AddRangeAsync(entities);
        public void Delete(T entity)
            => _dbContext.Set<T>().Remove(entity);
        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<T>().Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
            => _dbContext.Set<T>().RemoveRange(entities);
        public void Update(T entity)
            => _dbContext.Set<T>().Update(entity);

        public void UpdateRange(IEnumerable<T> entities)
            => _dbContext.Set<T>().UpdateRange(entities);

    }
}
