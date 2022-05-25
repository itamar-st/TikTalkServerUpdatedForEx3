using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Services;
using Domain;
using System.Text.Json.Nodes;
using webServerAPI.Controllers;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class contactsController : ControllerBase
    {
        private static ContactService _contactService;
        private static InvitationService _invitationService;

        public contactsController()
        {
            _contactService = new ContactService();
            _invitationService = new InvitationService();
        }
        [HttpGet]
        // GET: contactsController
        public List<ContactRequest> Index(string user)
        {
            //TODO: return not found exception if not exist
            return _contactService.GetAll(user);
        }
        [HttpGet("{id}")]
        // GET: contactsController/Details/5 
        public ContactRequest Details(string user, string id)
        {
            return _contactService.Get(user, id);
        }
        // POST: contactsController/Create
        [HttpPost]
        public void Create(string user, [Bind("Id, Name, Server")]Contact contact)
        { 
            //TODO: check how to get multiple args as json
            _contactService.Create(user, contact);
        }
        [HttpPut("{contactId}")]
        //put: contactsController/Edit/5
        public void Edit(string user, string contactId, [FromBody] JsonObject content)
        {
            _contactService.Edit(user, contactId, content);
        }
        [HttpDelete("{contactId}")]
        public void Delete(string user, string contactId)
        {
            _contactService.Delete(user, contactId);
        }
    }
}
