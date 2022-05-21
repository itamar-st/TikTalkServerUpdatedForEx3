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

        public User Get(int id)
        {
            return users.Find(x => x.Id == id);
        }
        //public void create(string username, string nickname, string password)
        //{
        //    int nextid = users.max(x => x.id) + 1;

        //    users.add(new user() { id = nextid, username = username,
        //        nickname = nickname, password = password});
        //}
        public void Create(User user)
        {
            users.Add(user);
        }

    }
}
