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
        private IHubContext<ChatHub> _hub;
        private readonly AppDbContext _context;
        public ChatController(IHubContext<ChatHub> hub, AppDbContext context)
        {
            _hub = hub;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string content)
        {
            var message = new Message { Content = content,SendTime=DateTime.Now };
            _context.Messages.Add(message);
            await  _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("ReceiveMessage",content+"|"+message.SendTime.ToString());
            return Ok();
        }
    }
}
