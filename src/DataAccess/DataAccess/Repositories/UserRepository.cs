using AppServices.Users.Repository;
using Domain;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IRepository<User> _repository;
        private ILogger<UserRepository> _logger;

        public UserRepository(
            ApplicationDbContext dbContext,


            IRepository<User> repository, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;

            _repository = repository;
            _logger = logger;
        }

        public async Task<IList<User>> GetAllAsync(CancellationToken token)
        {
            return await _repository.GetAllAsync(token);
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _repository.GetByIdAsync(id, token);
        }
   
        public async Task CreateAsync(User entity, CancellationToken token)
        {
            await _repository.CreateAsync(entity, token);                
        }

        public async Task UpdateAsync(User entity, CancellationToken token)
        {
            await _repository.UpdateAsync(entity, token);
        }

        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            await _repository.DeleteAsync(id, token);
        }



        public IList<User> GetUsersWithIncludeAsync(CancellationToken cancellationToken)
        {
            //var users = _dbContext.Users;
            //foreach (var user in users)
            //{ 
            //_dbContext.Entry(user).Collection(u => u.Orders).vaLoad();
            //_dbContext.Entry(user).Reference(u => u.Profile).Load();
            //}

            var users = _dbContext.Users.
             Include(x => x.Orders)
             .Include(x => x.Profile)
             .ToList();

            return users.ToList();
        }
    }
}