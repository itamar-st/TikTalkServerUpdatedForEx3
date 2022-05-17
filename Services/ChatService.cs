using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class ChatService
    {
        public static List<Chat> Chats = new List<Chat>();

        public List<Chat> GetAll()
        {
            return Chats;
        }

        public Chat Get(int contactId)
        {
            return Chats.Find(c => c.ContactId == contactId);
        }
        public void Create(int contactID)
        {
            int nextId = Chats.Max(x => x.Id) + 1;

            Chats.Add(new Chat()
            {
                Id = nextId,
                ContactId = contactID,
                messages = new List<Message>()
            });
        }
        public void Delete(int contactId)
        {
            Chats.RemoveAll(c => c.ContactId == contactId);
        }
    }
}
