using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Users.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAllAsync(CancellationToken token);
        Task<User> GetByIdAsync(Guid id, CancellationToken token);
        Task CreateAsync(User entity, CancellationToken token);
        Task UpdateAsync(User entity, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
