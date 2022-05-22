using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private static TransferService _transferService;

        public TransferController()
        {
            _transferService = new TransferService();
        }
        // POST api/<TransferController>
        [HttpPost]
        public void Post([Bind("From, To, Content")] Transfer transfer)
        {
            _transferService.SendMessage(transfer);
        }
    }
}
