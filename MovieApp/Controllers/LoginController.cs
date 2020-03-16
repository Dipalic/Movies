using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MoviesContext _context;

        public LoginController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _context.Users;
        }
       

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Login([FromBody] Users user)
        {
            var _user_ = _context.Users.ToList().Where(u => u.EmailId == user.EmailId && u.Password == user.Password).SingleOrDefault();
            return _user_ != default ? Ok(_user_) : (IActionResult)BadRequest("User Not Found");
        }


        // PUT: api/Login/5
        [HttpPut("{id}")]
        public bool SignOut(string EmailId)
        {
            Users user = _context.Users.ToList().Where(u => u.EmailId == EmailId).SingleOrDefault();
            //user.IsOnline = false;
            //Save();
            return true;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
