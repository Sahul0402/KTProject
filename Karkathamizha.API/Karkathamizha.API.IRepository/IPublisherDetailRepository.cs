using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IRepository
{
    public interface IPublisherDetailRepository
    {
        Task<Publisher> GetPublisherById(int id);
        Task<IEnumerable<Publisher>> GetAll();
        Task<int> AddUpdatePublisher(Publisher book);
        Task<string> DeletePublisher(int id);
    }
}
