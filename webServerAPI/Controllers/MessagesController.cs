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
        public List<Message> Index(string contactId)
        {
            return _messageService.GetAll(contactId);
        }

        [HttpGet("{contactId}/{msgId}")]
        //[Route("api/contacts/{contactId}/messages/{msgId}")]

        // GET: MessagesController/Details/5
        public Message Details(string contactId, int msgId)
        {
            return _messageService.Get(contactId, msgId);
        }

        // POST: MessagesController/Create
        [HttpPost("{contactId}")]
        //[Route("api/contacts/{contactId}/messages")]

        //[ValidateAntiForgeryToken]
        public void Create(string contactId, [FromBody] JsonObject content)
        {
             _messageService.Create(contactId, content);
        }
        [HttpPut("{contactId}/{msgId}")]
        //GET: MessagesController/Edit/5
        public void Edit(string contactId, int msgId, [FromBody] JsonObject content)
        {
            _messageService.Edit(contactId, msgId, content);
        }
        [HttpDelete("{contactId}/{msgId}")]
        public void Delete(string contactId, int msgId)
        {
            _messageService.Delete(contactId, msgId);
        }
    }
}
