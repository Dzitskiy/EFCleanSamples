using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Orders.Services
{
    public interface IOrderService
    {
        Task<IList<Order>> GetAllAsync(CancellationToken token);
        Task<Order> GetByIdAsync(Guid id, CancellationToken token);
        Task CreateAsync(Order entity, CancellationToken token);
        Task UpdateAsync(Order entity, CancellationToken token);
        Task DeleteAsync(Guid id, CancellationToken token);
    }
}
