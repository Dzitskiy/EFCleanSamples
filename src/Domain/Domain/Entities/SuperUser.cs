using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SuperUser : User
    {
        public bool IsAdmin { get; set; }
    }
}
