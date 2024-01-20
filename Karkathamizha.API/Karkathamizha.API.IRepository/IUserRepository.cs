using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmailId(string email);
        Task<IEnumerable<User>> GetAll();
        Task<int> AddUpdateUser(User book);
        Task<string> DeleteUser(int id);
    }
}
