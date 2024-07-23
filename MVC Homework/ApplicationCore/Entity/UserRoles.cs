using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Users User { get; set; }
        public Roles Role { get; set; }
    }
}
