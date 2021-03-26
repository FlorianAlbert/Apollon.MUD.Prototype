using Apollon.MUD.Prototype.Core.Interface.Enums;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ClientContext
    {
        private HubConnection HubConnection { get; }

        private IAvatar Avatar { get; set; }

        private ClientState ClientState { get; set; }

        public DungeonConfigurator DungeonConfigurator { get; set; }

        public IDungeon DungeonMock => DungeonMockData.Dungeon;

        private int? _DungeonId;
        private int? DungeonId
        {
            get => _DungeonId;
            set
            {
                _DungeonId = value;
                RoomId = null;
            }
        }

        private AvatarConfigurator AvatarConfigurator { get; }

        private IDungeonRepo DungeonRepo { get; }

        private int? RoomId { get; set; }

        public ClientContext(IDungeonRepo dungeonRepo, AvatarConfigurator avatarConfigurator, DungeonConfigurator dungeonConfigurator)
        {
            ClientState = ClientState.Inactive;
            AvatarConfigurator = avatarConfigurator;
            DungeonRepo = dungeonRepo;
            DungeonConfigurator = dungeonConfigurator;
            HubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/hubs/ConsoleHub")
                .Build();

            HubConnection.StartAsync();
        }

        public void ClientMessage(string message, string connectionId)
        {
            switch (ClientState)
            {
                case ClientState.Playing:
                    EvaluateCommand(message, connectionId);
                    break;
                case ClientState.SettingName:
                    if (AvatarConfigurator.SetName(message))
                    {
                        ClientState = ClientState.SettingRace;

                        SendMessageToClient($"Bitte gib deine Art ein. \nZur Verfügung stehen\n\t-: {string.Join("\n\t-", AvatarConfigurator.GetRaceNames())}", connectionId);
                    }
                    else
                    {
                        SendMessageToClient("Dieser Avatar existiert bereits. Vielleicht solltest du lieber einen eindeutigeren Namen wählen...", connectionId);
                    }
                    
                    break;
                case ClientState.SettingRace:
                    if (AvatarConfigurator.SetRace(message))
                    {
                        ClientState = ClientState.SettingClass;

                        SendMessageToClient($"Bitte gib deine Klasse ein. \nZur Verfügung stehen\n\t-: {string.Join("\n\t-", AvatarConfigurator.GetClassNames())}", connectionId);
                    }
                    else
                    {
                        SendMessageToClient("Diese Art hat noch kein lebendes Wesen je gesehen...?!", connectionId);
                    }
                    break;
                case ClientState.SettingClass:
                    if (AvatarConfigurator.SetClass(message))
                    {
                        (this.DungeonId, this.Avatar) = AvatarConfigurator.BuildAvatar(connectionId);
                        Avatar.Chat += SendMessageToClient;

                        ClientState = ClientState.Playing;

                        if (DungeonId.HasValue) RoomId = DungeonRepo.EnterDungeon(DungeonId.Value, Avatar);
                    }
                    else
                    {
                        SendMessageToClient("Klingt interessant, aber wähle lieber eine der verfügbaren Klassen!", connectionId);
                    }
                    break;
            }
        }

        private void EvaluateCommand(string message, string connectionId)
        {
            var stringParts = message.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            switch (stringParts[0].ToLower())
            {
                case "take":
                    DungeonRepo.TakeItem(RoomId.Value, Avatar, stringParts[1].ToLower());
                    break;
                case "inspect":
                    DungeonRepo.Inspect(RoomId.Value, Avatar, stringParts[1].ToLower());
                    break;
                case "exit":
                    DungeonRepo.LeaveDungeon(RoomId.Value, Avatar);
                    break;
                case "move":
                    DungeonRepo.ChangeRoom(RoomId.Value, Avatar, (EDirections)Enum.Parse(typeof(EDirections), stringParts[1].ToUpper()));
                    break;
            }
        }

        public bool EnterDungeonRequest(int dungeonId)
        {
            var dungeon = DungeonRepo.ActiveDungeons.Find(x => x.DungeonId == dungeonId);

            if (dungeon == null) return false;

            AvatarConfigurator.SetDungeon(dungeon);

            ClientState = ClientState.SettingName;

            

            return true;
        }

        public bool EnterMockDungeonRequest()
        {
            
            AvatarConfigurator.SetDungeon(DungeonMockData.Dungeon);

            ClientState = ClientState.SettingName;

            return true;
        }

        private async Task SendMessageToClient(string message, string connectionId)
        {
            await HubConnection.SendAsync("ReceiveMessage", message, connectionId);
        }
    }
}
