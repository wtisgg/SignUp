using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RegisterApi.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UserContext _context;

        public UserController(IConfiguration config, UserContext context)
        {
            _config = config;
            _context = context;

        }
        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Create(MyUser user)
        {
            if( _context.Users.Where(u => u.Email == user.Email).FirstOrDefault() !=null)
            {
                return Ok("Already Exist");
            }
            user.MemberSince = System.DateTime.Now;
           await _context.Users.AddAsync(user);
          await  _context.SaveChangesAsync();
            return Ok("Success");
        }
  

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public  IActionResult Login(Login user)
        {
            var userAvailable =  _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.UserId.ToString(),
                    userAvailable.Name,
                    userAvailable.Contact,
                    userAvailable.Email
 
                    )
                    );
            }
            return Ok("Failure");
        }
    }
}
