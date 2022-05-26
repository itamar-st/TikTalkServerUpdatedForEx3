using System;
using System.Text.Json.Nodes;
using Domain;
using Services;

namespace Services
{
    public interface IContactService
    {
        public List<ContactRequest> GetAll(string user);

        public ContactRequest Get(string user, string contactId);

        public bool Create(string user, Contact contact);

        public bool Edit(string user, string contactId, JsonObject content);
        public bool EditLastMsg(string user, string contactId, string last, string lastDate);
        public bool Delete(string user, string id);
    }
}