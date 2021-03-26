using System;
using Apollon.MUD.Prototype.Core.Domain;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Apollon.MUD.Prototype.Outbound.Ports.Storage;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ConsoleHub : Hub
    {
        private ClientContextProvider ClientContextProvider { get; }

        private AvatarConfigurator AvatarConfigurator { get; }

        private IDungeonRepo DungeonRepo { get; }

        private DungeonConfigurator DungeonConfigurator { get; }

        private IHubContext<ConsoleHub> HubContext { get; }

        public ConsoleHub(ClientContextProvider clientContextProvider, AvatarConfigurator avatarConfigurator,
            IDungeonRepo dungeonRepo, DungeonConfigurator dungeonConfigurator, IHubContext<ConsoleHub> hubContext)
        {
            ClientContextProvider = clientContextProvider;
            AvatarConfigurator = avatarConfigurator;
            DungeonRepo = dungeonRepo;
            DungeonConfigurator = dungeonConfigurator;
        }
        
        public async Task SendMessage(string message)
        {
            
            ClientContextProvider.Clients[Context.ConnectionId].ClientMessage(message, Context.ConnectionId);
        }

        public async Task ReceiveMessage(string message, string connectionId)
        {

            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public async Task EnterMockDungeonRequest()
        {
            ClientContextProvider.Clients[Context.ConnectionId].EnterMockDungeonRequest();
        }

        public async override Task OnConnectedAsync()
        {
            ClientContextProvider.Clients.Add(Context.ConnectionId, new ClientContext(DungeonRepo, AvatarConfigurator, DungeonConfigurator));
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ClientContextProvider.Clients.Remove(Context.ConnectionId);
        }
    }
}
