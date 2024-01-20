using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetPublisherById(Int16 id);
        Task<IEnumerable<Publisher>> GetAll();
        Task<Int16> AddUpdatePublisher(Publisher book);
        Task<string> DeletePublisher(Int16 id);
    }
}
