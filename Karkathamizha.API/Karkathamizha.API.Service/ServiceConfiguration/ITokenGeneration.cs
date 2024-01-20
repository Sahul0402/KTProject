using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.ServiceConfiguration
{
    public interface ITokenGeneration
    {
        Task<string> GenerateJwtToken(User user);
    }
}
