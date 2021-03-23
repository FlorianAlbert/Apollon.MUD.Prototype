using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Inbound.SignalR
{
    public class InboundTextHub : Hub
    {
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();

        public override async Task OnConnectedAsync()
        {
            Trace.TraceInformation("InboundTextHub started. ID: {0}", Context.ConnectionId);

            // TODO: check Name
            var userName = Context.User.Identity.Name;
            
            ConnectedUsers.TryGetValue(userName, out var existingUserConnectionIds);

            existingUserConnectionIds ??= new List<string>();
            
            existingUserConnectionIds.Add(Context.ConnectionId);
            
            ConnectedUsers.TryAdd(userName, existingUserConnectionIds);

            await base.OnConnectedAsync();
        }

        public async Task EnterDungeon(int dungeonId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, dungeonId.ToString());
        }

        public async Task LeaveDungeon(int dungeonId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, dungeonId.ToString());
        }
    }
}
