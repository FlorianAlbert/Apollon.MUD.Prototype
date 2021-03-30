using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Outbound.SignalR
{
    public class TextHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.Client("").SendAsync("ReceiveMessage", message);
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
