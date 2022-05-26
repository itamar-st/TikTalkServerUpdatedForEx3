using System;
using System.Text.Json.Nodes;
using Domain;
using Services;

namespace Services
{
    public class ContactService : IContactService
    {
        UserService userService = new UserService();
        public List<ContactRequest> GetAll(string user)
        {
            try
            {
                User currntUser = userService.Get(user);

                List<Contact> usersContacts = currntUser.Contacts;
                List<ContactRequest> contactsForSending = new List<ContactRequest>();
                foreach (Contact contact in usersContacts)
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
            catch { return null; }

        }

        public ContactRequest Get(string user, string contactId)
        {
            try
            {
                User currntUser = userService.Get(user);

                Contact currentContact = currntUser.Contacts.Find(x => x.Id == contactId);


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
            catch { return null; }


            }

        public bool Create(string user, Contact contact)
        {
            try
            {
                User currntUser = userService.Get(user);

                currntUser.Contacts.Add(contact);
                return true;
            }
            catch { return false; }

        }

        public bool Edit(string user, string contactId, JsonObject content)
        {
            try
            {
                User currntUser = userService.Get(user);

                Contact currentContact = currntUser.Contacts.Find(x => x.Id == contactId);


                currentContact.Name = content["name"].ToString();
                currentContact.Server = content["server"].ToString();
                return true;
            }
            catch { return false; }
        }
        public bool EditLastMsg(string user, string contactId, string last, string lastDate)
        {
            try
            {
                User currntUser = userService.Get(user);

                Contact currentContact = currntUser.Contacts.Find(x => x.Id == contactId);
                currentContact.Last = last;
                currentContact.Lastdate = lastDate;
                return true;
            }
            catch { return false; }
        }
        public bool Delete(string user, string id)
        {
            try
            {
                User currntUser = userService.Get(user);

                // TODO: deleting a contact that doesent exists - send error?
                currntUser.Contacts.RemoveAll(x => x.Id == id);
                return true;
            }
            catch { return false; }

        }
    }
}
