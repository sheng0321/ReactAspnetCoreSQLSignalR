using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}
