using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Interfaces.Dungeon
{
    public interface IDungeon
    {
        int DungeonId { get; init; }
        string DungeonDescription { get; set; }
        string DungeonEpoch { get; init; }
        int DefaultRoomId { get;  }

        List<IRace> ConfiguredRaces { get; init; }

        List<IClass> ConfiguredClasses { get; init; }

        List<IInspectable> ConfiguredInspectables { get; init; }

        List<IAvatar> AllAvatars { get; init; }

        List<INeighborship> Neighborships { get; init; }

        List<IRoom> Rooms { get; init; }

        bool AddNeighborship(int SourceId, EDirections fromSourceToSink, int SinkId);
        int RemoveNeighborship(int firstNeighborId, int secondNeighborId);
        IRoom AddRoom(bool asDefault = false);
        bool RemoveRoom(int RoomId);
        IRoom GetRoom(int roomID);
        void ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction);
        int Enter(IAvatar avatar);
    }
}
