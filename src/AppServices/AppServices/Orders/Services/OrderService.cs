using AppServices.Users.Services;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        //private readonly IRepository<User> _userRepository;

        //private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IRepository<Order> orderRepository,
            //IRepository<User> userRepository,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            //_userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IList<Order>> GetAllAsync(CancellationToken token)
        {     
            var data = await _orderRepository.GetAllAsync(token);

            if (data == null || data.Count == 0)
            {
                _logger.LogError("List is empty!");
            }
            return data;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _orderRepository.GetByIdAsync(id, token);
        }

        public async Task CreateAsync(Order entity, CancellationToken token)
        {
            await _orderRepository.CreateAsync(entity, token);
        }
        public async Task UpdateAsync(Order entity, CancellationToken token)
        {
            await _orderRepository.UpdateAsync(entity, token);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {

            await _orderRepository.DeleteAsync(id, token);
        }


    }
}
