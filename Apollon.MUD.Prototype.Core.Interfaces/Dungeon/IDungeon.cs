using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.EDirection;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Interfaces.Dungeon
{
    public interface IDungeon
    {
        public int DungeonId { get; }

        public bool AddNeighborship(int SourceId, EDirections fromSourceToSink, int SinkId);
        public IRoom AddRoom(bool asDefault = false);
        public void ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction);
        public int Enter(IAvatar avatar);
        public IRoom GetRoom(int roomID);
        public int RemoveNeighborship(int firstNeighborId, int secondNeighborId);
        public bool RemoveRoom(int RoomId);
    }
}
