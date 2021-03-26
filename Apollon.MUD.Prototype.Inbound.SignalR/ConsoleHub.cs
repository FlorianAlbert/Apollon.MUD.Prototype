using Apollon.MUD.Prototype.Core.Domain;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Inbound.SignalR
{
    public class ConsoleHub : Hub
    {
        private ClientContext ClientContext { get; }
        public ConsoleHub(ClientContext clientContext)
        {
            ClientContext = clientContext;
        }
        
        public async Task SendMessage(string message, string connectionId)
        {
            ClientContext.ClientMessage(message, connectionId);
        }

        public async Task SendMessageToClient(string message, string connectionId)
        {
            Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public async Task EnterMockDungeonRequest()
        {
            ClientContext.EnterMockDungeonRequest();
        }
    }
}
