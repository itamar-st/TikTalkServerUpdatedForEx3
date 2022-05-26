using System.Text.Json.Nodes;
using Domain;
namespace Services
{
    public class MessageService : IMessageService
    {
        UserService userService = new UserService();
        ContactService contactService = new ContactService();

        public List<Message> GetAll(string user, string contactId)
        {
            try
            {
                User currntUser = userService.Get(user);


                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);


                return currentContact.ChatWithContact;
            }
            catch { return null; }
        }

        public Message Get(string user, string contactId, int msgId)
        {
            try
            {
                User currntUser = userService.Get(user);

                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);


                return currentContact.ChatWithContact.Find(x => x.Id == msgId);
            }
            catch { return null; }

        }
        public bool Create(string user, string contactId, JsonObject content, bool fromTransfer)
        {
            try
            {
                int nextid;
                User currntUser = currntUser = userService.Get(user);

                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);

                if (currentContact.ChatWithContact.Count == 0)
                {
                    nextid = 0;
                }
                else
                {
                    nextid = currentContact.ChatWithContact.Max(x => x.Id) + 1;
                }
                Message message = new Message()
                {
                    Id = nextid,
                    Created = DateTime.Now.ToString(),
                    Content = content["content"].ToString(),
                    Sent = fromTransfer
                };
                currentContact.ChatWithContact.Add(message);
                contactService.EditLastMsg(user, contactId, message.Content, message.Created);
                return true;
            }
            catch { return false; }
            }


        public void Edit(string user, string contactId, int msgId, JsonObject content)
        {
            User currntUser = userService.Get(user);
            List<Contact> contacts = currntUser.Contacts;
            Contact currentContact = contacts.Find(x => x.Id == contactId);
            Message currentMessage = currentContact.ChatWithContact.Find(y => y.Id == msgId);
            currentMessage.Content = content["content"].ToString();
        }
        public bool Delete(string user, string contactId, int msgId)
        {
            try
            {
                User currntUser = userService.Get(user);

                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);

                // TODO: deleting a message that doesent exists - send error?
                currentContact.ChatWithContact.RemoveAll(x => x.Id == msgId);
                return true;
            }
            catch { return false; }

        }
    }
}
