using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class MessageService
    {
        public static List<Message> messages = new List<Message>();

        public List<Message> GetAll()
        {
            return messages;
        }

        public Message Get(int id)
        {
            return messages.Find(x => x.Id == id);
        }
        public void Create(string created, bool sent, string content)
        {
            int nextId = messages.Max(x => x.Id) + 1;

            messages.Add(new Message()
            {
                Id = nextId,
                Created = created,
                Sent = sent, //TODO: send true from here?
                Content = content
            });
        }
        public void Edit(int id, string created, bool sent, string content)
        {
            Message message = Get(id);

            message.Created = created;
                message.Sent = sent; //TODO: send true from here?
            message.Content = content;
            
        }
        public void Delete(int id)
        {
            messages.RemoveAll(x => x.Id == id);
        }
    }
}
