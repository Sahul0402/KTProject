using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Model
{
    public class LoginSuccess
    {
        public string Token { get; set; } = null!;
        public User UserInfo { get; set; }
    }
}
