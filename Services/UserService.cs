﻿using Domain;

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
            try
            {
                return _users;
            }
            catch { return null; }
        }


        // get user
        // GET api/<UsersController>/5
        public User Get(string id)
        {
            try
            {
                return _users.FirstOrDefault(x => x.Id == id);
            }
            catch { return null; }
        }


        // add user
        // POST api/<UsersController>
        //public void Post([FromBody] User user)
        public bool Post(User user)
        {
            try
            {
                _users.Add(user);
                return true;
            }
            catch { return false; }
        }


        // edit user
        // PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        // delete user
        // DELETE api/<UsersController>/5
        public bool Delete(string id)
        {
            try
            {
                _users.Remove(_users.Where(x => x.Id == id).First());
                return true;
            }
            catch { return false; }
        }
    }
}

