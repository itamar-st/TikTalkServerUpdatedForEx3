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
    public class ContactService
    {
        public static List<Contact> contacts = new List<Contact>();
        UserService userService = new UserService();
        public List<ContactRequest> GetAll(string user)
        {
            User currntUser = userService.Get(user);
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
            User currntUser = userService.Get(user);
            Contact userContact = currntUser.Contacts.Find(x => x.Id == contactId);
                ContactRequest contactRequest = new ContactRequest()
                {
                    Id = userContact.Id,
                    Name = userContact.Name,
                    Last = userContact.Last,
                    Lastdate = userContact.Lastdate,
                    Server = userContact.Server
                };
            return contactRequest;
            }

        public void Create(string user, Contact contact)
        {
            User currntUser = userService.Get(user);

            currntUser.Contacts.Add(contact);
        }

        public void Edit(string user, string contactId, JsonObject content)
        {
            //TODO: check if field actualy exists in JSON obj
            User currntUser = userService.Get(user);
            Contact currentContact = currntUser.Contacts.Find(x => x.Id == contactId);
            currentContact.Name = content["name"].ToString();
            currentContact.Server = content["server"].ToString();
        }

        public void Delete(string user, string id)
        {
            contacts.RemoveAll(x => x.Id == id);
        }
    }
}
