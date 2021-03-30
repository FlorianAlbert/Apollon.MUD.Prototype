using System;
using System.Threading.Tasks;
using Apollon.MUD.Prototype.Core.Interface.Enums;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using Microsoft.AspNetCore.SignalR.Client;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ClientContext
    {
        private int? _DungeonId;

        public ClientContext(IDungeonRepo dungeonRepo, AvatarConfigurator avatarConfigurator,
            DungeonConfigurator dungeonConfigurator)
        {
            ClientState = ClientState.Inactive;
            AvatarConfigurator = avatarConfigurator;
            DungeonRepo = dungeonRepo;
            DungeonConfigurator = dungeonConfigurator;
            HubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/hubs/ConsoleHub")
                .Build();

            HubConnection.StartAsync();
        }

        private HubConnection HubConnection { get; }

        private IAvatar Avatar { get; set; }

        private ClientState ClientState { get; set; }

        public DungeonConfigurator DungeonConfigurator { get; set; }

        public IDungeon DungeonMock => DungeonMockData.Dungeon;

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

                        SendMessageToClient(
                            $"Bitte gib deine Art ein. \nZur Verfügung stehen:\n\t-{string.Join("\n\t-", AvatarConfigurator.GetRaceNames())}",
                            connectionId);
                    }
                    else
                    {
                        SendMessageToClient(
                            "Dieser Avatar existiert bereits. Vielleicht solltest du lieber einen eindeutigeren Namen wählen...",
                            connectionId);
                    }

                    break;
                case ClientState.SettingRace:
                    if (AvatarConfigurator.SetRace(message))
                    {
                        ClientState = ClientState.SettingClass;

                        SendMessageToClient(
                            $"Bitte gib deine Klasse ein. \nZur Verfügung stehen:\n\t-{string.Join("\n\t-", AvatarConfigurator.GetClassNames())}",
                            connectionId);
                    }
                    else
                    {
                        SendMessageToClient("Diese Art hat noch kein lebendes Wesen je gesehen...?!", connectionId);
                    }

                    break;
                case ClientState.SettingClass:
                    if (AvatarConfigurator.SetClass(message))
                    {
                        (DungeonId, Avatar) = AvatarConfigurator.BuildAvatar(connectionId);
                        Avatar.Chat += SendMessageToClient;

                        ClientState = ClientState.Playing;

                        if (DungeonId.HasValue) RoomId = DungeonRepo.EnterDungeon(DungeonId.Value, Avatar);
                    }
                    else
                    {
                        SendMessageToClient("Klingt interessant, aber wähle lieber eine der verfügbaren Klassen!",
                            connectionId);
                    }

                    break;
            }
        }

        private void EvaluateCommand(string message, string connectionId)
        {
            var stringParts = message.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            switch (stringParts[0].ToLower())
            {
                case "nimm":
                    DungeonRepo.TakeItem(RoomId.Value, Avatar, stringParts[1].ToLower());
                    break;
                case "untersuche":
                    DungeonRepo.Inspect(RoomId.Value, Avatar, stringParts[1].ToLower());
                    break;
                case "beende":
                    DungeonRepo.LeaveDungeon(RoomId.Value, Avatar);
                    break;
                case "gehe":
                    RoomId = DungeonRepo.ChangeRoom(RoomId.Value, Avatar,
                        (EDirections) Enum.Parse(typeof(EDirections), stringParts[1].ToUpper()));
                    break;
                case "inventar":
                    DungeonRepo.ShowInventory(Avatar);
                    break;
                case "wirf":
                    DungeonRepo.ThrowItemAway(RoomId.Value, Avatar, stringParts[1].ToLower());
                    break;
                case "konsumiere":
                    DungeonRepo.ConsumeConsumable(Avatar, stringParts[1].ToLower());
                    break;
                case "schaue":
                    DungeonRepo.Show(RoomId.Value, Avatar);
                    break;
                case "hilfe":
                    Avatar.SendPrivateMessage(
                        "Mögliche Befehle sind: \n" +
                        "\t-Untersuche <Objekt> --- Liefert eine beschreibende Information über den gewünschten Gegenstand\n" +
                        "\t-Schaue --- Liefert eine Beschreibung des aktuellen Raums\n" +
                        "\t-Gehe <Himmelsrichtung> --- Bewegt den Avatar in den Raum in der gewünschten Himmelsrichtung\n" +
                        "\t-Nimm <Gegenstand> --- Nimmt den gewünschten Gegenstand in den Inventar auf\n" +
                        "\t-Wirf <Gegenstand> --- Befördert einen Gegenstand aus dem eigenen Inventar in den aktuellen Raum\n" +
                        "\t-Konsumiere <Nahrung> --- Lässt den Avatar den gewünschten Gegenstand aus dem Inventar konsumieren\n" +
                        "\t-Inventar --- Gibt den aktuellen Inhalt des Inventars aus\n" +
                        "\t-Beende --- Lässt den Avatar das Spiel verlassen");
                    break;
                default:
                    Avatar.SendPrivateMessage("Wie bitte...?");
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