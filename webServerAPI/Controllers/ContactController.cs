using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Services;
using Domain;
namespace ChatServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private static Services.ContactService contactService;

        public ContactController()
        {
            contactService = new Services.ContactService();
        }
        [HttpGet]
        // GET: ContactController
        public IEnumerable<Contact> Index()
        {
            //TODO: return not found exception if not exist
            return contactService.GetAll();
        }
        [HttpGet("{id}")]
        // GET: ContactController/Details/5 
        public Contact Details(int id)
        {
            return contactService.Get(id);
        }

        // POST: ContactController/Create
        [HttpPost]
        public void Create([Bind("UserName, NickName, ProfilePicURL, Server")]Contact contact)
        { 
            //TODO: check how to get multiple args as json
            contactService.Create(contact);
        }
        
    }
}
