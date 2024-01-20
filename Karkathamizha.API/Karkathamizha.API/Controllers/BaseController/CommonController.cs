using Karkathamizha.API.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karkathamizha.API.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }
        [HttpGet]
        public async Task<bool> IsEmailExists(string email)
        {
            return await _commonService.IsEmailExists(email);
        }
    }
}
