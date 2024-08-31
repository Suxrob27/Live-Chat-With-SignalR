using Microsoft.AspNetCore.SignalR;

namespace OnlineChat__Online_Server_Part_.SignalR
{
    public class Chathub : Hub
    {
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }
    }
}
