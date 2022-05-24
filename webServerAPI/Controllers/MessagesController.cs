using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
using System.Text.Json.Nodes;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //TODO: add response code?
    public class MessagesController : ControllerBase
    {
        private static MessageService _messageService;
        // GET: MessagesController
        public MessagesController()
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

        // GET: MessagesController/Details/5
        public Message Details(string user, string contactId, int msgId)
        {
            return _messageService.Get(user, contactId, msgId);
        }

        // POST: MessagesController/Create
        [HttpPost("{contactId}")]
        //[Route("api/contacts/{contactId}/messages")]

        //[ValidateAntiForgeryToken]
        public void Create(string user, string contactId, [FromBody] JsonObject content)
        {
            // true because i sent the message
             _messageService.Create(user, contactId, content, true);

        }
        [HttpPut("{contactId}/{msgId}")]
        //GET: MessagesController/Edit/5
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
