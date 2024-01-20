using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    internal class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly ICommonRepository _commonRepository;

        public PublisherService(IPublisherRepository publisherRepository, ICommonRepository commonRepository)
        {
            _publisherRepository = publisherRepository;
            _commonRepository = commonRepository;
        }

        public Task<Int16> AddUpdatePublisher(Publisher model)
        {
            return _publisherRepository.AddUpdatePublisher(model);
        }

        public Task<IEnumerable<Publisher>> GetAll()
        {
            return _publisherRepository.GetAll();
        }
    }
}
