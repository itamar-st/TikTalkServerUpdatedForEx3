using System.Text.Json.Nodes;
using Domain;
namespace Services
{
    public interface IMessageService
    {
        // return all the messages of the user and the secific contact
        public List<Message> GetAll(string user, string contactId);

        // return the message with the msgId id between user and contactId
        public Message Get(string user, string contactId, int msgId);

        //create a new message in the conversation between user and contactId
        //retun true on success and false otherwise
        //public bool Create(string user, string contactId, JsonObject content, bool fromTransfer);
        public bool Create(string user, string contactId, string content, bool fromTransfer);


        // edit an existing msg between user and contactId
        public bool Edit(string user, string contactId, int msgId, JsonObject content);

        //delet a message between user and contactId from the DB
        public bool Delete(string user, string contactId, int msgId);
    }
}
