using Domain;
using Microsoft.AspNetCore.SignalR;


namespace webServerAPI.Hubs
{
    public class ChatHub : Hub
    {
        /* when one client use SendMessage function, all clients that are listening to the RecivedMessage event, 
            check if they are "dst", and if so, they execute a predetermind function */
        public async Task SendMessage(string src, string dst)
        {
            await Clients.All.SendAsync("ReceiveMessage", src, dst);
        }

        /* when one client use AskToConnect function, all clients that are listening to the AcceptConnection event, 
            check if they are "dst", and if so, they execute a predetermind function */
        public async Task AskToConnect(string dst)
        {
            await Clients.All.SendAsync("AcceptConnection", dst);
        }
    }
}