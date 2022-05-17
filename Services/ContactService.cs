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
        public static List<Contact> contacts = new List<Contact>();

        public List<Contact> GetAll(int id)
        {
            return contacts;
        }

        public Contact Get(int id)
        {
            return contacts.Find(x => x.Id == id);
        }
        public void Create(string username, string nickname,
            string profilepicURL, string password, string lastmessage, string lastmsgdate, string server)
        {
            int nextId = contacts.Max(x => x.Id) + 1;

            contacts.Add(new Contact()
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
            string profilepicURL, string password, string lastmessage, string lastmsgdate, string server, Contact currentContact)
        {
            Contact contact = Get(id);

            contact.Id = id;
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
