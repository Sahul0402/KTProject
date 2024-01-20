using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IService
{
    public interface IPublisherService
    {
        Task<Int16> AddUpdatePublisher(Publisher model);
        Task<IEnumerable<Publisher>> GetAll();
    }
}
