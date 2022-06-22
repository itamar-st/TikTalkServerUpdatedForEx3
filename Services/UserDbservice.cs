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
                List<User> users = db.Usersdb.Include(c => c.Contacts).ToList<User>();
                return users.Find(u => u.Id == id);
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
