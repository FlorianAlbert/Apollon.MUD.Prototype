using Apollon.MUD.Prototype.Core.Implementation.Enums;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using System;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ClientContext
    {
        private IAvatar Avatar { get; set; }

        private ClientState ClientState { get; set; }

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

        public ClientContext(IDungeonRepo dungeonRepo, AvatarConfigurator avatarConfigurator)
        {
            ClientState = ClientState.Inactive;
            AvatarConfigurator = avatarConfigurator;
            DungeonRepo = dungeonRepo;
        }

        public void ClientMessage(string message)
        {
            switch (ClientState)
            {
                case ClientState.Playing:
                    EvaluateCommand(message);
                    break;
                case ClientState.SettingName:
                    if (AvatarConfigurator.SetName(message))
                    {
                        ClientState = ClientState.SettingRace;

                        SendMessageToClient($"Bitte gib deine Art ein. \nZur Verfügung stehen\n\t-: {string.Join("\n\t-", AvatarConfigurator.GetRaceNames())}");
                    }
                    else
                    {
                        SendMessageToClient("Dieser Avatar existiert bereits. Vielleicht solltest du lieber einen eindeutigeren Namen wählen...");
                    }
                    
                    break;
                case ClientState.SettingRace:
                    if (AvatarConfigurator.SetRace(message))
                    {
                        ClientState = ClientState.SettingClass;

                        SendMessageToClient($"Bitte gib deine Klasse ein. \nZur Verfügung stehen\n\t-: {string.Join("\n\t-", AvatarConfigurator.GetClassNames())}");
                    }
                    else
                    {
                        SendMessageToClient("Diese Art hat noch kein lebendes Wesen je gesehen...?!");
                    }
                    break;
                case ClientState.SettingClass:
                    if (AvatarConfigurator.SetClass(message))
                    {
                        (this.DungeonId, this.Avatar) = AvatarConfigurator.BuildAvatar();
                        Avatar.Chat += SendMessageToClient;

                        ClientState = ClientState.Playing;

                        if (DungeonId.HasValue) RoomId = DungeonRepo.EnterDungeon(DungeonId.Value, Avatar);
                    }
                    else
                    {
                        SendMessageToClient("Klingt interessant, aber wähle lieber eine der verfügbaren Klassen!");
                    }
                    break;
            }
        }

        private void EvaluateCommand(string message)
        {
            throw new NotImplementedException();
        }

        public bool EnterDungeonRequest(int dungeonId)
        {
            var dungeon = DungeonRepo.ActiveDungeons.Find(x => x.DungeonId == dungeonId);

            if (dungeon == null) return false;

            AvatarConfigurator.SetDungeon(dungeon);

            ClientState = ClientState.SettingName;

            SendMessageToClient("Bitte gib den Namen deines Avatars ein: ");

            return true;
        }

        private void SendMessageToClient(string message)
        {

        }
    }
}
