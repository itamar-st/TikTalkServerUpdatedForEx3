using Domain;

namespace Services
{
    public interface InterfaceUsersService
    {
        // GET: api/<UsersController>
        public IEnumerable<User> Get();

        // GET api/<UsersController>/5
        public User Get(string id);

        // POST api/<UsersController>
        //public void Post([FromBody] User user);
        public bool Post(User user);

        // PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value);

        // DELETE api/<UsersController>/5
        public bool Delete(string id);
    }


}

