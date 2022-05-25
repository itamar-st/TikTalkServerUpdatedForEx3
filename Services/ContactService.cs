using System;
using System.Text.Json.Nodes;
using Domain;
using Services;

namespace Services
{
    public class ContactService
    {
        UserService userService = new UserService();
        public List<ContactRequest> GetAll(string user)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return null; }

            List<Contact> usersContacts = currntUser.Contacts;
            List<ContactRequest> contactsForSending = new List<ContactRequest>();
            foreach(Contact contact in usersContacts)
            {
                ContactRequest contactRequest = new ContactRequest()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Last = contact.Last,
                    Lastdate = contact.Lastdate,
                    Server = contact.Server
                };
                 contactsForSending.Add(contactRequest);
            }
            return contactsForSending;

        }

        public ContactRequest Get(string user, string contactId)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) {return null;}

            Contact currentContact;
            if ((currentContact = currntUser.Contacts.Find(x => x.Id == contactId)) == null) { return null; }
            
            ContactRequest contactRequest = new ContactRequest()
                {
                    Id = currentContact.Id,
                    Name = currentContact.Name,
                    Last = currentContact.Last,
                    Lastdate = currentContact.Lastdate,
                    Server = currentContact.Server
                };
            return contactRequest;
            }

        public bool Create(string user, Contact contact)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }

            currntUser.Contacts.Add(contact);
            return true;
        }

        public bool Edit(string user, string contactId, JsonObject content)
        {
            //TODO: check if field actualy exists in JSON obj
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }

            Contact currentContact;
            if ((currentContact = currntUser.Contacts.Find(x => x.Id == contactId)) == null) { return false; }

            currentContact.Name = content["name"].ToString();
            currentContact.Server = content["server"].ToString();
            return true;
        }

        public bool Delete(string user, string id)
        {
            User currntUser;
            if ((currntUser = userService.Get(user)) == null) { return false; }
            // TODO: deleting a contact that doesent exists - send error?
            currntUser.Contacts.RemoveAll(x => x.Id == id);
            return true;

        }
    }
}
