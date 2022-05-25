using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;
using Services;
namespace Services
{
    public class MessageService
    {
        UserService userService = new UserService();

        public List<Message> GetAll(string user, string contactId)
        {
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
            return currentContact.ChatWithContact;
        }

        public Message Get(string user, string contactId, int msgId)
        {
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
            return currentContact.ChatWithContact.Find(x => x.Id == msgId);
        }
        public void Create(string user, string contactId, JsonObject content, bool fromTransfer)
        {
            int nextid;
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
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
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
            Message currentMessage = currentContact.ChatWithContact.Find(y => y.Id == msgId);
            currentMessage.Content = content["content"].ToString();
        }
        public void Delete(string user, string contactId, int msgId)
        {
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
            currentContact.ChatWithContact.RemoveAll(x => x.Id == msgId);
        }
    }
}
