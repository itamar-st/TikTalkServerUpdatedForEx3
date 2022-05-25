using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
using System.Text.Json.Nodes;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    //TODO: add response code?
    public class messagesController : ControllerBase
    {
        private static MessageService _messageService;
        // GET: messagesController
        public messagesController()
        {
            _messageService = new MessageService();
        }
        [HttpGet("{contactId}/messages")]
        public IActionResult Index(string user, string contactId)
        {
            List<Message> messages = _messageService.GetAll(user, contactId);
            if(messages == null)
            {
                return BadRequest();
            }
            return Ok(messages);
        }

        [HttpGet("{contactId}/messages/{msgId}")]

        // GET: messagesController/Details/5
        public IActionResult Details(string user, string contactId, int msgId)
        {
            Message message = _messageService.Get(user, contactId, msgId);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        // POST: messagesController/Create
        [HttpPost("{contactId}/messages")]
        //[Route("api/contacts/{contactId}/messages")]

        //[ValidateAntiForgeryToken]
        public IActionResult Create(string user, string contactId, [FromBody] JsonObject content)
        {
            // true because i sent the message
             if(_messageService.Create(user, contactId, content, true) == false)
            {
                return BadRequest();
            }
            return Created("api/contacts/{contactId}/messages", "");

        }
        [HttpPut("{contactId}/messages/{msgId}")]
        //GET: messagesController/Edit/5
        public IActionResult Edit(string user, string contactId, int msgId, [FromBody] JsonObject content)
        {
            _messageService.Edit(user, contactId, msgId, content);
            return NoContent();
        }
        [HttpDelete("{contactId}/messages/{msgId}")]
        public IActionResult Delete(string user, string contactId, int msgId)
        {
            _messageService.Delete(user, contactId, msgId);
            return NoContent();
        }
    }
}
