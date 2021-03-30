using System;
using System.Collections.Generic;
using System.Linq;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Interface.Dungeon
{
    public class DungeonSkeleton : IDungeon
    {
        public int DungeonId { get; init; }
        public string DungeonDescription { get; set; }
        public string DungeonEpoch { get; init; }
        public List<IRace> ConfiguredRaces { get; init; }
        public List<IClass> ConfiguredClasses { get; init; }
        public List<IInspectable> ConfiguredInspectables { get; init; }
        public List<INeighborship> Neighborships { get; init; } = new() ;
        public List<IRoom> Rooms { get; init; } = new();
        public int DefaultRoomId { get; set; }

        public DungeonSkeleton (string dungeonEpoch)
        {
            DungeonEpoch = dungeonEpoch;
        }

        public List<IAvatar> AllAvatars
        {
            get
            {
                return Rooms.SelectMany(x => x.Inspectables).OfType<IAvatar>().ToList();
            }
        }

        public IRoom AddRoom(bool asDefault = false)
        {
            //TODO does foreach truely iterate over the index structure of the list? -> found on stackoverflow but I'm not sure
            var nextIndex = 0;
            //_Rooms.Sort((r1, r2) => r1.CompareTo(r2));
            Rooms.OrderBy(x => x.RoomId);
            foreach (var room in Rooms)
                if (room.RoomId == nextIndex)
                    nextIndex++;
                else break;
            var newRoom = new RoomSkeleton(nextIndex);

            if (asDefault || Rooms.Count == 0) DefaultRoomId = newRoom.RoomId;

            Rooms.Add(newRoom);

            return newRoom;
        }

        public IRoom GetRoom(int roomId)
        {
            return Rooms.Find(r => r.RoomId == roomId);
        }

        public bool RemoveRoom(int roomId)
        {
            //TODO update Neigborship Directions in Room
            Neighborships.RemoveAll(n => n.IsInvolved(roomId));
            return Rooms.Remove(Rooms.Find(r => r.RoomId == roomId));
        }

        public bool AddNeighborship(int sourceId, EDirections fromSourceToSink, int sinkId)
        {
            //TODO update Neigborship Directions in Room
            var newNeighborship = new Neighborship(sourceId, fromSourceToSink, sinkId);

            var neighborAlreadyExists = Neighborships
                .Select(x => x).Count(x => x.SourceId.Equals(newNeighborship.SourceId) &&
                                           x.FromSourceToSinkDirection == newNeighborship.FromSourceToSinkDirection ||
                                           x.SinkId.Equals(newNeighborship.SinkId) &&
                                           x.FromSinkToSourceDirection == newNeighborship.FromSinkToSourceDirection ||
                                           x.SinkId.Equals(newNeighborship.SourceId) &&
                                           x.FromSinkToSourceDirection == newNeighborship.FromSourceToSinkDirection ||
                                           x.SourceId.Equals(newNeighborship.SinkId) &&
                                           x.FromSourceToSinkDirection == newNeighborship.FromSinkToSourceDirection) != 0;

            if (neighborAlreadyExists) return false;

            Neighborships.Add(newNeighborship);
            return true;
        }

        public int Enter(IAvatar avatar)
        {
            avatar.SendPrivateMessage("!!!Um zu erfahren wie gespielt wird, gib 'Hilfe' ein!!!");
            GetRoom(DefaultRoomId).Enter(avatar);
            return DefaultRoomId;
        }

        public int ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction)
        {
            int newRoomId;

            var requestedNeighborship = Neighborships.Find(x => x.SourceId == currentRoomId && x.FromSourceToSinkDirection == direction);

            if (requestedNeighborship != null)
            {
                newRoomId = requestedNeighborship.SinkId;
            }
            else
            {
                requestedNeighborship = Neighborships.Find(x => x.SinkId == currentRoomId && x.FromSinkToSourceDirection == direction);

                if (requestedNeighborship != null)
                {
                    newRoomId = requestedNeighborship.SourceId;
                }
                else
                {
                    avatar.SendPrivateMessage("Es ist keine gute Idee diesen Weg einzuschlagen. Gehe lieber in eine der angegebenen Richtungen...");
                    return currentRoomId;
                }
            }

            GetRoom(currentRoomId).Leave(avatar);
            GetRoom(newRoomId).Enter(avatar);

            return newRoomId;
        }

        public int RemoveNeighborship(int firstNeighborId, int secondNeighborId)
        {
            //TODO update Neigborship Directions in Room
            //TODO add Direction? removes all neighborships between firsNeighbor and secondNeighbor
            return Neighborships.RemoveAll(n => n.SourceId == firstNeighborId && n.SinkId == secondNeighborId ||
                                            n.SourceId == secondNeighborId && n.SinkId == firstNeighborId);
        }
    }
}