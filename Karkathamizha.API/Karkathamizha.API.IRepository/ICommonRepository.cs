using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface ICommonRepository
    {
        Task<bool> IsEmailExists(string email);
    }
}
