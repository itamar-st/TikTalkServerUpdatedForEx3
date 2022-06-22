using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;
    public class userDbservice: IUsersService
    {
        ////hardcoded list to represent the DB
        //private static ICollection<User> _users = new List<User>() {
        //                                                                new User() {
        //                                                                    Id = "emma",
        //                                                                    Name = "emma",
        //                                                                    Password = "12345678Aa",
        //                                                                    ProfilePic = "",
        //                                                                    Contacts = new List<Contact>()
        //                                                                    {
        //                                                                        new Contact() {
        //                                                                            Id = "itamar",
        //                                                                            Name = "itamar",
        //                                                                            Last = "good, how are you?",
        //                                                                            Lastdate = "28/05/2022 12:12:26",
        //                                                                            Server = "localhost:5051",
        //                                                                            ChatWithContact = new List<Message>()
        //                                                                            {
        //                                                                                new Message() {
        //                                                                                    Id = 0,
        //                                                                                    Created = "28/05/2022 12:12:23",
        //                                                                                    Sent = true,
        //                                                                                    Content = "hi itamar, how are you?"
        //                                                                                },

        //                                                                                 new Message() {
        //                                                                                    Id = 1,
        //                                                                                    Created = "28/05/2022 12:12:26",
        //                                                                                    Sent = false,
        //                                                                                    Content = "good, how are you?"
        //                                                                                }
        //                                                                            }

        //                                                                        }

        //                                                                    }
        //                                                                } ,

        //                                                                new User()
        //                                                                {
        //                                                                    Id = "gil",
        //                                                                    Name = "gili",
        //                                                                    Password = "12345678Aa",
        //                                                                    ProfilePic = "",
        //                                                                    Contacts = new List<Contact>()
        //                                                                },

        //                                                                new User()
        //                                                                {
        //                                                                    Id = "dude",
        //                                                                    Name = "dude",
        //                                                                    Password = "12345678Aa",
        //                                                                    ProfilePic = "",
        //                                                                    Contacts = new List<Contact>()
        //                                                                },

        //                                                                new User()
        //                                                                {
        //                                                                    Id = "itamar",
        //                                                                    Name = "itamar",
        //                                                                    Password = "12345678Aa",
        //                                                                    ProfilePic = "",
        //                                                                    Contacts = new List<Contact>()
        //                                                                    {
        //                                                                         new Contact() {
        //                                                                            Id = "emma",
        //                                                                            Name = "emma",
        //                                                                            Last = "good, how are you?",
        //                                                                            Lastdate = "28/05/2022 12:12:26",
        //                                                                            Server = "localhost:5051",
        //                                                                            ChatWithContact = new List<Message>()
        //                                                                             {
        //                                                                                new Message() {
        //                                                                                    Id = 0,
        //                                                                                    Created = "28/05/2022 12:12:23",
        //                                                                                    Sent = false,
        //                                                                                    Content = "hi itamar, how are you?"
        //                                                                                },

        //                                                                                 new Message() {
        //                                                                                    Id = 1,
        //                                                                                    Created = "28/05/2022 12:12:26",
        //                                                                                    Sent = true,
        //                                                                                    Content = "good, how are you?"
        //                                                                                }
        //                                                                            }

        //                                                                        }
        //                                                                    }
        //                                                                }
        //                                                            };


        // get all users
        // GET: api/<UsersController>
        public IEnumerable<User> Get()
        {
            using (var db = new UserContext())
            {
                try
                {
                return db.Usersdb.Include(c =>c.Contacts).ToList();
                //return db.Usersdb.ToList();
                }
                catch { return null; }
            }
        }


        // get user
        // GET api/<UsersController>/5
        public User Get(string id)
        {
        using (var db = new UserContext())
        {
            try
            {
                //IEnumerable<User> users = Get();
                //User? user = db.Users.Where(b => b.Id == id).Include(b => b.Contacts).FirstOrDefault();
                //var user = db.Users.Include(u => u.Contacts).Where(b => b.Id == id);
                User? user = db.Usersdb.Include(c => c.Contacts).ToList<User>().Find(u=> u.Id == id);
                return user;
            }
            catch { return null; }

        }
        }


        // add user
        // POST api/<UsersController>
        //public void Post([FromBody] User user)
        public bool Post(User user)
        {
        using (var db = new UserContext())
        {
            try
            {
                db.Add(user);
                db.SaveChanges();  
                return true;
            }
            catch { return false; }

        }
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
        using (var db = new UserContext())
        {
            try
            {
                db.Remove(id);
                return true;
            }
            catch { return false; }

        }
        }
    }
