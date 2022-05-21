using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Services
{
    public class ContactService
    {
        public static List<Contact> contacts = new List<Contact>();

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact Get(string id)
        {
            return contacts.Find(x => x.Id == id);
        }

        public void Create(Contact contact)
        {
            contacts.Add(contact);
        }

        public void Delete(string id)
        {
            contacts.RemoveAll(x => x.Id == id);
        }
    }
}
