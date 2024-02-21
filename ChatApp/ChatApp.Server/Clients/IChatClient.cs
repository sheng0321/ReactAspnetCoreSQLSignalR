using ChatApp.Server.Model;

namespace ChatApp.Server.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
