using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class ContactService
    {
        public static List<Chats> contacts = new List<Chats>();

        public List<Chats> GetAll()
        {
            return contacts;
        }

        public Chats Get(int id)
        {
            return contacts.Find(x => x.Id == id);
        }
        public void Create(string username, string nickname,
            string profilepicURL, string password, string lastmessage, string lastmsgdate, string server)
        {
            int nextId = contacts.Max(x => x.Id) + 1;

            contacts.Add(new Chats()
            {
                Id = nextId,
                UserName = username,
                Nickname = nickname,
                ProfilePicURL = profilepicURL,
                LastMessage = lastmessage,
                LastMsgDate = lastmsgdate,
                Server = server
            });
        }
        public void Edit(int id, string username, string nickname,
            string profilepicURL, string password, string lastmessage, string lastmsgdate, string server, Chats currentContact)
        {
            Chats contact = Get(id);

            contact.UserName = username;
            contact.Nickname = nickname;
            contact.ProfilePicURL = profilepicURL;
            contact.LastMessage = lastmessage;
            contact.LastMsgDate = lastmsgdate;
            contact.Server = server;
        }
        public void Delete(int id)
        {
            contacts.RemoveAll(x => x.Id == id);
        }
    }
}
