using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private InterfaceUsersService service;

        public UserController()
        {
            this.service = new UserService();
        }


        // get all users
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = service.Get();
            if(users == null) return NotFound();

            return Ok(users);
        }


        // get user
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = service.Get(id);
            if(user == null) return NotFound();

            return Ok(user);
        }


        // add user
        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(service.Post(user) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }


        // delete user
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(service.Delete(id) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
