using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class MessageService
    {
        public static List<Message> messages = new List<Message>();

        public List<Message> GetAll(string user, string contactId)
        {

            Contact currentContact = Services.ContactService.contacts.Find(x => x.Id == contactId);
            return currentContact.ChatWithContact;
        }

        public Message Get(string user, string contactId, int msgId)
        {
            Contact currentContact =  Services.ContactService.contacts.Find(x => x.Id == contactId);
            return currentContact.ChatWithContact.Find(x => x.Id == msgId);
        }
        public void Create(string user, string contactId, JsonObject content, bool fromTransfer)
        {
            int nextid;
            Contact currentContact = Services.ContactService.contacts.Find(x => x.Id == contactId);
            if(currentContact.ChatWithContact.Count == 0)
            {
                nextid = 0;
            }
            else
            {
             nextid = currentContact.ChatWithContact.Max(x => x.Id) + 1;
            }

            currentContact.ChatWithContact.Add(new Message()
            {
                Id = nextid,
                Created = DateTime.Now.ToString(),
                Content = content["content"].ToString(),
                Sent = fromTransfer
            });
            }


        public void Edit(string user, string contactId, int msgId, JsonObject content)
        {
            Contact currentContact = Services.ContactService.contacts.Find(x => x.Id == contactId);
            Message currentMessage = currentContact.ChatWithContact.Find(y => y.Id == msgId);
            currentMessage.Content = content["content"].ToString();
        }
        public void Delete(string user, string contactId, int msgId)
        {
            Contact currentContact = Services.ContactService.contacts.Find(x => x.Id == contactId);
            currentContact.ChatWithContact.RemoveAll(x => x.Id == msgId);
        }
    }
}
