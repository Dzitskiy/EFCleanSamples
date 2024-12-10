using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность Пользователь.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>

        //[Column("user_id")]

        //[Required]
        // [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public UserProfile? Profile { get; set; } // Reference navigation to dependent


    }


}
