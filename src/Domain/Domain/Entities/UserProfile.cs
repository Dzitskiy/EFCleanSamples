using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string Address { get; set; }

        /// <summary>
        /// ID пользователя, создавшего объявление
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Навигационное свойство на <see cref="User"/>
        /// </summary>
        public User User { get; set; } // Required reference navigation to principal
    }
}
