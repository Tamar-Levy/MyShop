using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices _UserServices;

        public UsersController(IUserServices userServices)
        {
            _UserServices = userServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return 
        //}

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        [Route("login")]
        public ActionResult<User> Login([FromQuery] string userName , [FromQuery] string password)
        {
            User user = _UserServices.LoginUser(userName, password);
            if(user!=null)
                   return Ok(user);
             return BadRequest();


        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User user)
        {
            User userRegister = _UserServices.RegisterUser(user);
            if (userRegister != null)
            {
                if (userRegister.FirstName == "weak password")
                    return NoContent();
              return Ok(userRegister);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("password")]
        public int CheckPassword([FromBody]string password)
        {
             return _UserServices.UserPassword(password);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userToUpdate)
        {
            User userUpdate = _UserServices.UpdateUser(id,userToUpdate);
            if (userUpdate != null)
                return Ok(userUpdate);
            return BadRequest();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
