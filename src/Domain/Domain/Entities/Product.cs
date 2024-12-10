using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Навигационное свойство на <see cref="Order"/>
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Навигационное поле на .
        /// </summary>
        public IList<Tag> Tags { get; set; } = new List<Tag>();   
    }
}
