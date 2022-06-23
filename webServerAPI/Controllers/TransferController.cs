using Domain;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post([Bind("From, To, Content")] Transfer transfer)
        {
            if (_transferService.onMessageArrival(transfer) == false)
            {
                return BadRequest();
            }
            await PushNotification(transfer);
            return NoContent();
            
        }

        private async Task PushNotification(Transfer transfer)
        {
            if(FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions { Credential = GoogleCredential.FromFile("tiktokFirebase.json") });
            }
            string token = Firebase.Get(transfer.To);
            if(token == null)
            {
                return;
            }
            var msg = new FirebaseAdmin.Messaging.Message()
            {
                Token = token,
                Data = new Dictionary<string, string>()
                {
                    { "From", transfer.From },
                    { "Content", transfer.Content }
                },
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = "New message from " + transfer.From,
                    Body = transfer.Content
                }
            };

            await FirebaseMessaging.DefaultInstance.SendAsync(msg);
        }
    }
}
