using Domain;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    //1
    public interface IRepository<T> where T : BaseEntity        
    {
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
