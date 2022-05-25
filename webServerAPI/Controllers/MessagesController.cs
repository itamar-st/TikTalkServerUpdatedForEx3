using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
using System.Text.Json.Nodes;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //TODO: add response code?
    public class messagesController : ControllerBase
    {
        private static MessageService _messageService;
        // GET: messagesController
        public messagesController()
        {
            _messageService = new MessageService();
        }

        [HttpGet("{contactId}")]
        public List<Message> Index(string user, string contactId)
        {
            return _messageService.GetAll(user, contactId);
        }

        [HttpGet("{contactId}/{msgId}")]
        //[Route("api/contacts/{contactId}/messages/{msgId}")]

        // GET: messagesController/Details/5
        public Message Details(string user, string contactId, int msgId)
        {
            return _messageService.Get(user, contactId, msgId);
        }

        // POST: messagesController/Create
        [HttpPost("{contactId}")]
        //[Route("api/contacts/{contactId}/messages")]

        //[ValidateAntiForgeryToken]
        public void Create(string user, string contactId, [FromBody] JsonObject content)
        {
            // true because i sent the message
             _messageService.Create(user, contactId, content, true);

        }
        [HttpPut("{contactId}/{msgId}")]
        //GET: messagesController/Edit/5
        public void Edit(string user, string contactId, int msgId, [FromBody] JsonObject content)
        {
            _messageService.Edit(user, contactId, msgId, content);
        }
        [HttpDelete("{contactId}/{msgId}")]
        public void Delete(string user, string contactId, int msgId)
        {
            _messageService.Delete(user, contactId, msgId);
        }
    }
}
