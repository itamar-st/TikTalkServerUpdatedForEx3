using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class UserService : IService<User>
    {
        public static List<User> users = new List<User>();

        public List<User> GetAll()
        {
            return users;
        }
        public User Get(string id)
        {
            return users.Find(x => x.Id == id);
        }
        public void Delete(string id)
        {
            users.RemoveAll(x => x.Id == id);
        }
        public void Create(User user)
        {
            users.Add(user);
        }
    }
}
