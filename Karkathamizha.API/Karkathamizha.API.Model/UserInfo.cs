using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class UserInfo
    {
        public User User { get; set; } = null!;
        public UserDetails UserDetails { get; set; } = null!;
    }
}
