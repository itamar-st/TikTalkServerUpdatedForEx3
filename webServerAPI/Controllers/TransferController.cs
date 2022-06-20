using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System.Text.Json.Nodes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transferController : ControllerBase
    {
        private static TransferService _transferService;

        public transferController()
        {
            _transferService = new TransferService();
        }
        // POST api/<transferController>
        [HttpPost]
        public IActionResult Post([Bind("From, To, Content")] Transfer transfer)
        {
            if (_transferService.SendMessage(transfer) == false)
            {
                return BadRequest();
            }
            return NoContent();
            
        }
    }
}
