using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private ILogger<EfCoreRepository<T>> _logger;

        public EfCoreRepository(ApplicationDbContext dbContext, ILogger<EfCoreRepository<T>> logger)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _logger = logger;
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, token);
        }
   
        public async Task CreateAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task UpdateAsync(T entity, CancellationToken token)
        {
            var (result, storedEntity) = await TryFindEntity(entity.Id, token);
            if (!result) return;

            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var (result, storedEntity) = await TryFindEntity(id, token);
            if (!result) return;

            _dbSet.Remove(storedEntity!);
            await _dbContext.SaveChangesAsync(token);
        }

        private async Task<(bool Result, T? entity)> TryFindEntity(Guid id, CancellationToken token)
        {
            var entity = await _dbSet.Where(e => e.Id == id).FirstOrDefaultAsync(token);
            var result = entity is not null;
            if (!result)
            {
                _logger.LogWarning($"Entity {typeof(T)} not found", nameof(id));
            }
            return (result, entity);
        }
    }
}
