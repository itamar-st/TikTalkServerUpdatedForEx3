using System;
using System.Text.Json.Nodes;
using Domain;
using Microsoft.EntityFrameworkCore;
using Services;
namespace Services
{
    public class ContactDbService : IContactService
    {
        IUsersService userService = new userDbservice();
        public List<Contact> GetAll(string user)
        {
            using (var db = new UserContext())
            {
                try
                {
                    // get from DB
                    return db.Contactsdb.
                        Include(c => c.ChatWithContact)
                        .ToList<Contact>()
                        .FindAll(u=>u.UserIdNum == user);

                }
                // if failed
                catch { return null; }

        }

    }

        public Contact Get(string user, string contactId)
        {
            using (var db = new UserContext())
            {
                try
                {
                    // get from DB
                    List<Contact> contacts = db.Contactsdb.Include(c => c.ChatWithContact).ToList<Contact>();
                    return contacts.Find(u => u.UserIdNum == user && u.Id == contactId);
            }
            catch { return null; }

            }


        }


        public bool Create(string user, Contact contact)
        {
                using (var db = new UserContext())
                {
                    try
                    {
                    // add to DB
                    contact.UserIdNum = user;
                    db.Add(contact);
                        db.SaveChanges();
                        return true;
                    }
                    catch { return false; }

                }
                
            }

        public bool Edit(string user, string contactId, JsonObject content)
        {
            try
            {
                User currntUser = userService.Get(user);
                //get user contacts
                Contact currentContact = currntUser.Contacts.Find(x => x.Id == contactId);

                // edit the name and server
                currentContact.Name = content["name"].ToString();
                currentContact.Server = content["server"].ToString();
                return true;
            }
            catch { return false; }
        }
        public bool EditLastMsg(string user, string contactId, string last, string lastDate)
        {
            using (var db = new UserContext())
            {
                try
                {
                    // find the contact to change
                Contact currentContact = Get(user, contactId);
                currentContact.Last = last;
                currentContact.Lastdate = lastDate;
                    //update the DB
                    db.Attach(currentContact);
                    db.Entry(currentContact).Property(c => c.Last).IsModified = true;
                    db.Entry(currentContact).Property(c => c.Lastdate).IsModified = true;
                    db.SaveChanges();
                return true;
            }
            // false if failed
            catch { return false; }

            }
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
            // false if failed
            catch { return false; }

        }
    }
}
