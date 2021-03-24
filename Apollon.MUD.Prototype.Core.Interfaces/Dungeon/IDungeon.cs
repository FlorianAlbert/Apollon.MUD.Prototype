using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Interfaces.Dungeon
{
    public interface IDungeon
    {
        int DungeonId { get; }

        bool AddNeighborship(int SourceId, EDirections fromSourceToSink, int SinkId);
        IRoom AddRoom(bool asDefault = false);
        void ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction);
        int Enter(IAvatar avatar);
        IRoom GetRoom(int roomID);
        int RemoveNeighborship(int firstNeighborId, int secondNeighborId);
        bool RemoveRoom(int RoomId);
    }
}
