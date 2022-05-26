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

                // get the contact from the DB
                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);


                return currentContact.ChatWithContact;
            }
            // if not exists or an error occurde 
            catch { return null; }
        }
        public Message Get(string user, string contactId, int msgId)
        {
            try
            {
                User currntUser = userService.Get(user);

                // get the contact from the DB
                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);


                return currentContact.ChatWithContact.Find(x => x.Id == msgId);
            }
            // if not exists or an error occurde 
            catch { return null; }

        }

        public bool Create(string user, string contactId, JsonObject content, bool fromTransfer)
        {
            try
            {
                int nextid;
                User currntUser = currntUser = userService.Get(user);

                // get the contact from the DB
                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);
                //give the msg an id
                if (currentContact.ChatWithContact.Count == 0)
                {
                    nextid = 0;
                }
                else
                {
                    nextid = currentContact.ChatWithContact.Max(x => x.Id) + 1;
                }
                //create the message
                Message message = new Message()
                {
                    Id = nextid,
                    Created = DateTime.Now.ToString(),
                    Content = content["content"].ToString(),
                    Sent = fromTransfer
                };
                //push to the DB
                currentContact.ChatWithContact.Add(message);
                contactService.EditLastMsg(user, contactId, message.Content, message.Created);
                return true;
            }
            // if not exists or an error occurde 
            catch { return false; }
            }

        public bool Edit(string user, string contactId, int msgId, JsonObject content)
        {
            try
            {
                User currntUser = userService.Get(user);
                // get the contact from the DB
                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);
                // get the msg from the the conversation and change the content
                Message currentMessage = currentContact.ChatWithContact.Find(y => y.Id == msgId);
                currentMessage.Content = content["content"].ToString();
                return true;
            }
            // if not exists or an error occurde 
            catch { return false; }

        }
        public bool Delete(string user, string contactId, int msgId)
        {
            try
            {
                User currntUser = userService.Get(user);

                // get the contact from the DB
                List<Contact> contacts = currntUser.Contacts;
                Contact currentContact = contacts.Find(x => x.Id == contactId);

                // TODO: deleting a message that doesent exists - send error?
                currentContact.ChatWithContact.RemoveAll(x => x.Id == msgId);
                return true;
            }
            // if not exists or an error occurde 
            catch { return false; }

        }
    }
}
