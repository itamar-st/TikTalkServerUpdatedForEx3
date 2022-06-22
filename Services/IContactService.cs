using System;
using System.Text.Json.Nodes;
using Domain;
using Services;

namespace Services
{
    public interface IContactService
    {
        // return a all the contacts of the user
        public List<Contact> GetAll(string user);

        // return the contactId in user's contact list
        public Contact Get(string user, string contactId);

        // create a new contact for user
        public bool Create(string user, Contact contact);

        //edit an existing contact in user contacts
        public bool Edit(string user, string contactId, JsonObject content);
        // edit the last msg from contat
        public bool EditLastMsg(string user, string contactId, string last, string lastDate);
        //delete the contaxt from user contacts
        public bool Delete(string user, string id);
    }
}