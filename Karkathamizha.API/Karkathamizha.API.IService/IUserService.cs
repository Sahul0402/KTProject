using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IService
{
    public interface IUserService
    {   
        Task<int> AddUpdateUser(User user);
        Task<string> DeleteUser(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(int id);        
    }
}
