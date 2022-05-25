using System.Text.Json.Nodes;
using Domain;
namespace Services
{
    public class MessageService
    {
        UserService userService = new UserService();

        public List<Message> GetAll(string user, string contactId)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return null; }

            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact;
            if((currentContact = contacts.Find(x => x.Id == contactId)) == null) { return null; }

            return currentContact.ChatWithContact;
        }

        public Message Get(string user, string contactId, int msgId)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return null; }

            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact;
            if ((currentContact = contacts.Find(x => x.Id == contactId)) == null) { return null; }

            return currentContact.ChatWithContact.Find(x => x.Id == msgId);
        }
        public bool Create(string user, string contactId, JsonObject content, bool fromTransfer)
        {
            int nextid;
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }

            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact;
            if ((currentContact = contacts.Find(x => x.Id == contactId)) == null) { return false; }

            if (currentContact.ChatWithContact.Count == 0)
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
            return true;
            }


        public bool Edit(string user, string contactId, int msgId, JsonObject content)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }

            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact;
            if ((currentContact = contacts.Find(x => x.Id == contactId)) == null) { return false; }

            Message currentMessage = currentContact.ChatWithContact.Find(y => y.Id == msgId);
            currentMessage.Content = content["content"].ToString();
            return true;
        }
        public bool Delete(string user, string contactId, int msgId)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }

            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact;
            if ((currentContact = contacts.Find(x => x.Id == contactId)) == null) { return false; }

            // TODO: deleting a message that doesent exists - send error?
            currentContact.ChatWithContact.RemoveAll(x => x.Id == msgId);
            return true;
        }
    }
}
