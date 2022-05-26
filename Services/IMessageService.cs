using System.Text.Json.Nodes;
using Domain;
namespace Services
{
    public interface IMessageService
    {
        public List<Message> GetAll(string user, string contactId);

        public Message Get(string user, string contactId, int msgId);
        public bool Create(string user, string contactId, JsonObject content, bool fromTransfer);


        public bool Edit(string user, string contactId, int msgId, JsonObject content);
        public bool Delete(string user, string contactId, int msgId);
    }
}
