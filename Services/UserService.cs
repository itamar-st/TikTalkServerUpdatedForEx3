using Domain;

namespace Services
{
    public class UserService : InterfaceUsersService
    {
        private static ICollection<User> _users = new List<User>() {
                                                                        new User() { 
                                                                            Id = "Emma",
                                                                            Name = "Grandma",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                            {
                                                                                new Contact() {
                                                                                    Id = "Tweety",
                                                                                    Name = "Tweety",
                                                                                    Last = "hi",
                                                                                    Lastdate = "5.5.5",
                                                                                    Server = "123",
                                                                                    ChatWithContact = new List<Message> { }

                                                                                }

                                                                            }
                                                                        } ,

                                                                        new User()
                                                                        {
                                                                            Id = "Gil",
                                                                            Name = "Gili", 
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                        },

                                                                        new User()
                                                                        {
                                                                            Id = "Dude",
                                                                            Name = "Dude",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                        },

                                                                        new User()
                                                                        {
                                                                            Id = "Itamar",
                                                                            Name = "Itamar",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                        }
                                                                    };


        // get all users
        // GET: api/<UsersController>
        public IEnumerable<User> Get()
        {
            return _users;
        }


        // get user
        // GET api/<UsersController>/5
        public User Get(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }


        // add user
        // POST api/<UsersController>
        //public void Post([FromBody] User user)
        public void Post(User user)
        {
            _users.Add(user);
        }


        // edit user
        // PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        // delete user
        // DELETE api/<UsersController>/5
        public void Delete(string id)
        {
            _users.Remove( _users.Where(x => x.Id == id).First() );
        }
    }
}

