using AppServices.Users.Repository;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Users.Services
{
    public class UserService : IUserService
    {
        //private readonly IRepository<User> _userRepository;
        private readonly IUserRepository _userRepository;


        private readonly ILogger<UserService> _logger;

        public UserService(
            //IRepository<User> userRepository,
            IUserRepository userRepository,

            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<IList<User>> GetAllAsync(CancellationToken token)
        {


            var data = await _userRepository.GetAllAsync(token);
            if (data == null || data.Count == 0)
            {
                _logger.LogError("List is empty!");
            }

            var users = _userRepository.GetUsersWithIncludeAsync(token);
            return users;


            return data;
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _userRepository.GetByIdAsync(id, token);
        }

        public async Task CreateAsync(User entity, CancellationToken token)
        {
            await _userRepository.CreateAsync(entity, token);
        }
        public async Task UpdateAsync(User entity, CancellationToken token)
        {


            await _userRepository.UpdateAsync(entity, token);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var currentUser = await _userRepository.GetByIdAsync(id, token);

            if (currentUser != null)
            {

                await _userRepository.DeleteAsync(id, token);
            }

        }
    }
}