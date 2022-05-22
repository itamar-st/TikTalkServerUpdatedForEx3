using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Services;
using Domain;
using System.Text.Json.Nodes;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private static ContactService _contactService;

        public ContactController()
        {
            _contactService = new ContactService();
        }
        [HttpGet]
        // GET: ContactController
        public IEnumerable<Contact> Index()
        {
            //TODO: return not found exception if not exist
            return _contactService.GetAll();
        }
        [HttpGet("{id}")]
        // GET: ContactController/Details/5 
        public Contact Details(string id)
        {
            return _contactService.Get(id);
        }
        // POST: ContactController/Create
        [HttpPost]
        public void Create([Bind("Id, Name, Server")]Contact contact)
        { 
            //TODO: check how to get multiple args as json
            _contactService.Create(contact);
        }
        [HttpPut("{contactId}")]
        //put: ContactController/Edit/5
        public void Edit(string contactId, [FromBody] JsonObject content)
        {
            _contactService.Edit(contactId, content);
        }
        [HttpDelete("{contactId}")]
        public void Delete(string contactId)
        {
            _contactService.Delete(contactId);
        }
    }
}
