using ChatApp.Server.Clients;
using ChatApp.Server.Hubs;
using ChatApp.Server.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;
        public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            // run some logic...

            await _chatHub.Clients.All.ReceiveMessage(message);
        }

        //[HttpPost("Submit")]
        //public async Task<IActionResult> Submit([FromBody] string content)
        //{
        //    var message = new Message { Content = content, SendTime = DateTime.Now };
        //    _context.Messages.Add(message);
        //    await _context.SaveChangesAsync();

        //    await _hub.Clients.All.SendAsync("ReceiveMessage", content);
        //    return Ok();
        //}
    }
}
