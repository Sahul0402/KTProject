using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IService
{
    public interface ICommonService
    {
        Task<bool> IsEmailExists(string email);
    }
}
