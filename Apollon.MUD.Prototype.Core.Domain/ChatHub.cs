using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string from, string message)
        {
            await Clients.AllExcept(new []{Context.ConnectionId}).SendAsync("ReceiveMessage", from, "All", message);
        }
    }
}