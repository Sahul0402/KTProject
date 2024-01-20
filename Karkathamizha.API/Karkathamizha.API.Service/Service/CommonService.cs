using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        public async Task<bool> IsEmailExists(string email)
        {
            return await _commonRepository.IsEmailExists(email);
        }
    }
}
