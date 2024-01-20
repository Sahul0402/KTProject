using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public Int16 RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
