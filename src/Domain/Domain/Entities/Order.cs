using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        /// <summary>
        /// ID пользователя, создавшего объявление
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Навигационное свойство на <see cref="User"/>
        /// </summary>
        public User User { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

    }
}
