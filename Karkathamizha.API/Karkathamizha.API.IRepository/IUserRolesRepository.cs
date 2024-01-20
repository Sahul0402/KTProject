using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IUserRolesRepository
    {
        Task<List<UserRoles>> GetUserRole(int userId);
    }
}
