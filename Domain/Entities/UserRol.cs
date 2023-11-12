using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRol
    {
        public int UserId { get; set; }
        public User Users { get; set; }
        public int RolId { get; set; }
        public Rol Rols { get; set; }
    }
}