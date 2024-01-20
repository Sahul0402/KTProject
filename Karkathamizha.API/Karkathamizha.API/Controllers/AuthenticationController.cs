using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Karkathamizha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _accountService;
        private readonly IUserService _userService;
        public AuthenticationController(IAuthenticationService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginSuccess>> Login(Login model)
        {
            if (model == null)
            {
                return BadRequest("Unauthorized User.");
            }
            var response = await _accountService.Login(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return response;
        }

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register(Register model)
        {
            Log.Information("Start RegisterUser()");
            if (model == null)
            {
                Log.Error("Register model object sent from client is null.");
                return BadRequest("Model object is null");
            }
            if (!ModelState.IsValid)
            {
                Log.Error("Invalid model object sent from client.");
                return BadRequest("Invalid model object");
            }

            int userId = await _accountService.Registeration(model);
            if (userId > 0)
            {
                //    var response = await _userService.AddUserDetails(userId);
            }
            return userId == null ? NotFound("User Information not found.") : Ok(userId);
            //if (response == null)
            //{
            //    return NotFound("User Information not found.");
            //}
            //return Ok(response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(Login model)
        {
            if (model == null)
            {
                return BadRequest("Unauthorized User.");
            }
            var response = await _accountService.ForgotPassword(model);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
