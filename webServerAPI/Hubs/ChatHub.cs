using Domain;
using Microsoft.AspNetCore.SignalR;


namespace webServerAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string src, string dst)
        {
            await Clients.All.SendAsync("ReceiveMessage", src, dst);
        }

        public async Task AskToConnect(string dst)
        {
            await Clients.All.SendAsync("AcceptConnection", dst);
        }
    }
}