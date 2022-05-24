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
        public IEnumerable<User> Get()
        {
            return service.Get();
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
        public void Post([FromBody] User user)
        {
            service.Post(user);
        }


        // delete user
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(id);
        }

    }
}
