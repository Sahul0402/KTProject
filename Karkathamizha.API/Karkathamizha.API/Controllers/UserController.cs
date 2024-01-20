using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Karkathamizha.API.Model;
using Karkathamizha.API.IService;
using Serilog;
using Karkathamizha.API.Controllers.BaseController;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Karkathamizha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseAPIController
    {
        private readonly IUserService _userService;
        public static IWebHostEnvironment _environment;
        public UserController(IUserService userService, IWebHostEnvironment environment)
        {
            _userService = userService;
            _environment = environment;
        }

        [HttpPost()]
        [Route("AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (user is null)
            {
                Log.Error("user sent from client is null.");
                return BadRequest("user object is null");
            }
            if (!ModelState.IsValid)
            {
                Log.Error("Invalid user object sent from client.");
                return BadRequest("Invalid model object");
            }
            
            //var response = await _userService.AddUserDetails(user);
            int userId = await _userService.AddUpdateUser(user);
            if (userId >= 0)
                return Ok($"User Id = {userId} updated successfullly.");
            else
                return Ok($"New User Id = {userId} Created successfullly.");
        }

        //public async Task<ActionResult<User>> AddUserwithFileUpload([FromForm] User user, int id)
        //{
        //    if (user is null)
        //    {
        //        Log.Error("user sent from client is null.");
        //        return BadRequest("user object is null");
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        Log.Error("Invalid user object sent from client.");
        //        return BadRequest("Invalid model object");
        //    }
        //    string path = _environment.WebRootPath + "\\UserImage\\";

        //    foreach (IFormFile item in Request.Form.Files)
        //    {
        //        //var exactPath1 = Path.Combine(Directory.GetCurrentDirectory(), "\\UserImage\\");
        //        //var path = Directory.GetCurrentDirectory() + "\\UserImage\\";
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        if (item.FileName.Length > 0)
        //        {
        //            using (FileStream fileStream = System.IO.File.Create(path + item.FileName))
        //            {
        //                item.CopyTo(fileStream);
        //                fileStream.Flush();
        //            }
        //        }
        //    }
        //    //var response = await _userService.AddUserDetails(user);
        //    int userId = await _userService.AddUpdateUser(user);
        //    if (userId >= 0)
        //        return Ok($"User Id = {userId} updated successfullly.");
        //    else
        //        return Ok($"New User Id = {userId} Created successfullly.");
        //    //return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound($"User Id = {id} doesn't exist.");

            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }

        [HttpGet()]
        [Route("GetAllUser")]
        public async Task<IEnumerable<User>> GetAllUser()
        {
            //return await _userService.GetAll();
            return await GetAll();
        }

        private async Task<IEnumerable<User>> GetAll()
        {
            UserDetails UserDetail = new UserDetails();

            List<User> lstAuthor = new List<User>()
            {
                new User(){ UserId = 1,UserName="கற்க",Name="karka",Email="support@karkathamizha.com",Mobile="81228801",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 2,UserName="தொல்காப்பியர்",Name="Tholkappiyar",Email="tholkappiyar@kt.com",Mobile="81228802",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 3,UserName="திருவள்ளூவர்",Name="Thiruvalluvar",Email="thiruvalluvar@kt.com",Mobile="81228803",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 4,UserName="எஸ்.ராகவன்",Name="S.Ragavan",Email="SRagavan@kt.com",Mobile="81228804",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 5,UserName="எம்.எஸ்.உதயமூர்த்தி",Name="M.S.Udayamurthy",Email="msudayamurthy@kt.com",Mobile="81228805",UserDetail = new UserDetails(){ FaceBook =""} },
                new User(){ UserId = 6,UserName="சந்தோஷ் நாராயணன்",Name="Santhosh Narayanan",Email="ensanthosh@gmail.com@kt.com",Mobile="81228806",UserDetail = new UserDetails(){ FaceBook ="santhosh.narayanan.319"} },
                new User(){ UserId = 7,UserName="முத்துக்கிருஷ்ணன்",Name="Muthukrishnan",Email="muthukrishnan@karkathamizha.com@kt.com",Mobile="81228807",UserDetail = new UserDetails(){ FaceBook ="Muthukrishnan"} },
                new User(){ UserId = 8,UserName="அதியமான்",Name="Athiyaman",Email="athiy61@yahoo.co.in@kt.com",Mobile="81228808",UserDetail = new UserDetails(){ FaceBook ="athiyaman.athiyaman.940641"} },
                new User(){ UserId = 9,UserName="வாஸந்தி",Name="Vaasanthi",Email="vaasanthi@karkathamizha.com@kt.com",Mobile="81228809",UserDetail = new UserDetails(){ FaceBook ="vaasanthi"} },
                new User(){ UserId = 10,UserName="உளிமகிழ் ராஜ்கமல்",Name="Ulimagizh Rajkamal",Email="Ulimagizh@kt.com",Mobile="81228810",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100008080955808"} },
                new User(){ UserId = 11,UserName="பாலசுப்ரமணியம்",Name="J.Balasubramaniam",Email="Balasubramaniam@kt.com",Mobile="81228811",UserDetail = new UserDetails(){ FaceBook ="BaluMIDS"} },
                new User(){ UserId = 12,UserName="ராகவன்",Name="Pa.Raghavan",Email="Raghavan@kt.com",Mobile="81228812",UserDetail = new UserDetails(){ FaceBook ="AuthorPara"} },
                new User(){ UserId = 13,UserName="ஜீவசுந்தரி",Name="B.Jeevasundari",Email="Jeevasundari@kt.com",Mobile="81228813",UserDetail = new UserDetails(){ FaceBook ="jeevasundaribalan"} },
                new User(){ UserId = 14,UserName="கணேசன்",Name="G.Ganesan",Email="Ganesan@kt.com",Mobile="81228814",UserDetail = new UserDetails(){ FaceBook ="ganesan.gurusamy.1800"} },
                new User(){ UserId = 15,UserName="முத்துநிலவன்",Name="Muthunilavan",Email="Muthunilavan@kt.com",Mobile="81228815",UserDetail = new UserDetails(){ FaceBook ="muthu.nilavan.52"} },
                new User(){ UserId = 16,UserName="தீபா",Name="J.Deepa",Email="Deepa@kt.com",Mobile="81228816",UserDetail = new UserDetails(){ FaceBook ="deepa.janakiraman.9"} },
                new User(){ UserId = 17,UserName="கருந்தேள் ராஜேஷ்",Name="Karundhel Rajesh",Email="Rajesh@kt.com",Mobile="81228817",UserDetail = new UserDetails(){ FaceBook ="rajesh.scorpi"} },
                new User(){ UserId = 18,UserName="சோம வள்ளியப்பன்",Name="Soma Valliappan",Email="Valliappan@kt.com",Mobile="81228818",UserDetail = new UserDetails(){ FaceBook ="soma.valliyappan"} },
                new User(){ UserId = 19,UserName="சிவசுப்பிரமணியன்",Name="A.Sivasubramanian",Email="Sivasubramanian@kt.com",Mobile="81228819",UserDetail = new UserDetails(){ FaceBook ="sivasubramanian.in"} },
                new User(){ UserId = 20,UserName="ராஜன் குறை",Name="Rajan Kurai Krishnan",Email="Krishnan@kt.com",Mobile="81228820",UserDetail = new UserDetails(){ FaceBook ="rajan.k.krishnan"} },
                new User(){ UserId = 21,UserName="சொக்கன்",Name="N.Chokkanathan",Email="Chokkanathan@kt.com",Mobile="81228821",UserDetail = new UserDetails(){ FaceBook ="nchokkan"} },
                new User(){ UserId = 22,UserName="பவா செல்லதுரை",Name="Bava Chelladurai",Email="Chelladurai@kt.com",Mobile="81228822",UserDetail = new UserDetails(){ FaceBook ="bavachelladurai"} },
                new User(){ UserId = 23,UserName="இந்திரன்",Name="Indran Rajendran",Email="Rajendran@kt.com",Mobile="81228823",UserDetail = new UserDetails(){ FaceBook ="indran.rajendran.7"} },
                new User(){ UserId = 24,UserName="பாலகிருஷ்ணன்",Name="R.Balakrishnan",Email="Balakrishnan@kt.com",Mobile="81228824",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100011737148867"} },
                new User(){ UserId = 25,UserName="K.செயராமன்",Name="Jayaraman",Email="Jayaraman@kt.com",Mobile="81228825",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100044112903885"} },
                new User(){ UserId = 25,UserName="S.செயராமன்",Name="Jayaram",Email="Jayaram@kt.com",Mobile="81228826",UserDetail = new UserDetails(){ FaceBook ="profile.php?id=100044112903885"} },
            };

            return lstAuthor;
        }

        [HttpGet()]
        [Route("GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound($"User Id = {id} doesn't exist.");
            return Ok(user);
        }
    }
}
