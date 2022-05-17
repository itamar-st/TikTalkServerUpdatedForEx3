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
        public void Create(string username, string nickname, string profilepicURL, string password)
        {
            int nextId = users.Max(x => x.Id) + 1;

            users.Add(new User() { Id = nextId, UserName = username,
                Nickname = nickname, ProfilePicURL = profilepicURL, Password = password});
        }

    }
}
