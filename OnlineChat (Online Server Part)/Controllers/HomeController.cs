using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineChat__Online_Server_Part_.SignalR;
using System.Diagnostics;

namespace OnlineChat__Online_Server_Part_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<Chathub> _hubContext;
        public HomeController(IHubContext<Chathub> hubContext)
        {
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(string user, string msg)
        {
            // Your business logic here...   
            // Send the message to all connected clients  
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, msg);
            return Ok();
        }

    }
}
