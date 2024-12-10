
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class Tag : BaseEntity
    {
        string Name { get; set; }

        /// <summary>
        /// Навигационное поле на .
        /// </summary>
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
