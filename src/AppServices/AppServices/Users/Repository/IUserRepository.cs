using Domain.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Users.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetUsersWithIncludeAsync(CancellationToken cancellationToken);
    }
}
