using Karkathamizha.API.IRepository;
using Karkathamizha.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarkaThamizha.API.Repository.Repository
{
    public class PublisherDetailRepository : IPublisherDetailRepository
    {
        public Task<int> AddUpdatePublisher(Publisher book)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeletePublisher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Publisher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Publisher> GetPublisherById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
