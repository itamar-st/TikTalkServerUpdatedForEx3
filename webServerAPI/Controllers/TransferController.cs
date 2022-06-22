using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System.Text.Json.Nodes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //controller for the Transfer model

    public class transferController : ControllerBase
    {
        private static ITransferService _transferService;

        public transferController()
        {
            _transferService = new TransferDbService();
        }
        // POST api/transfer
        //activated when the user recieves a message from other users
        [HttpPost]
        public IActionResult Post([Bind("From, To, Content")] Transfer transfer)
        {
            if (_transferService.onMessageArrival(transfer) == false)
            {
                return BadRequest();
            }
            return NoContent();
            
        }
    }
}
