using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static IList<User> Users => new List<User>()
        {
            new User()
            {
                Id = new Guid("5e357370-0f32-4f79-862d-a3754743929d"),
                Email = "admin@mail.ru",
                Name = "Admin",
            }
        };

        public static IList<SuperUser> SuperUsers => new List<SuperUser>()
        {
             new SuperUser()
            {
                Id = new Guid("0c378a48-4a0c-444a-8e48-3d0541ba053f"),
                Email = "admin@mail.ru",
                Name = "SuperAdmin",
                IsAdmin = true
            }
        };

        public static IList<Order> Orders => new List<Order>()
        {
            new Order()
            {
                Id = new Guid("5345b291-5464-45e0-b529-9777d64580f7"),
                UserId = new Guid("5e357370-0f32-4f79-862d-a3754743929d"),
            }
        };

        public static IList<Product> Products => new List<Product>()
        {
            new Product{
                Id = new Guid("02d1a7ac-60ca-40dc-b955-9eb5b8d8123d"),
                OrderId = new Guid("5345b291-5464-45e0-b529-9777d64580f7"),
                Name = "Product1",
                //Tags = new List<Tag> {
                //    new Tag{
                //        Id = Guid.NewGuid()
                //    }
                }
        };
    }
}



