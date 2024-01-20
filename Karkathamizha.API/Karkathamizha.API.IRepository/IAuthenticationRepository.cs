using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IAuthenticationRepository
    {
        Task<int> Registeration(Register model);
        Task<LoginSuccess> Login(Login account);

    }
}
