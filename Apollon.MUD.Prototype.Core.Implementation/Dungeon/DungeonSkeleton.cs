using System;
using System.Collections.Generic;
using System.Linq;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Implementation.Dungeon
{
    public class DungeonSkeleton : IDungeon
    {
        public int DungeonId { get; }
        public string DungeonDescription { get; set; }
        public string DungeonEpoch { get; }
        public List<IRace> ConfiguredRaces { get; }
        public List<IClass> ConfiguredClasses { get; }
        protected List<Neighborship> _Neighborships = new();
        protected List<IRoom> _Rooms = new();
        private int DefaultRoomId { get; set; }

        public DungeonSkeleton (string dungeonEpoch)
        {
            DungeonEpoch = dungeonEpoch;
        }

        public List<IAvatar> AllAvatars
        {
            get
            {
                return _Rooms.SelectMany(x => x.Inspectables).OfType<IAvatar>().ToList();
            }
        }

        public IRoom AddRoom(bool asDefault = false)
        {
            //TODO does foreach truely iterate over the index structure of the list? -> found on stackoverflow but I'm not sure
            var nextIndex = 0;
            //_Rooms.Sort((r1, r2) => r1.CompareTo(r2));
            _Rooms.OrderBy(x => x.RoomId);
            foreach (var room in _Rooms)
                if (room.RoomId == nextIndex)
                    nextIndex++;
                else break;
            var newRoom = new RoomSkeleton(nextIndex);

            if (asDefault || _Rooms.Count == 0) DefaultRoomId = newRoom.RoomId;

            _Rooms.Add(newRoom);

            return newRoom;
        }

        public IRoom GetRoom(int roomId)
        {
            return _Rooms.Find(r => r.RoomId == roomId);
        }

        public bool RemoveRoom(int roomId)
        {
            _Neighborships.RemoveAll(n => n.IsInvolved(roomId));
            return _Rooms.Remove(_Rooms.Find(r => r.RoomId == roomId));
        }

        public bool AddNeighborship(int sourceId, EDirections fromSourceToSink, int sinkId)
        {
            var newNeighborship = new Neighborship(sourceId, fromSourceToSink, sinkId);

            var neighborAlreadyExists = _Neighborships
                .Select(x => x).Count(x => x.SourceId.Equals(newNeighborship.SourceId) &&
                                           x.FromSourceToSinkDirection == newNeighborship.FromSourceToSinkDirection ||
                                           x.SinkId.Equals(newNeighborship.SinkId) &&
                                           x.FromSinkToSourceDirection == newNeighborship.FromSinkToSourceDirection ||
                                           x.SinkId.Equals(newNeighborship.SourceId) &&
                                           x.FromSinkToSourceDirection == newNeighborship.FromSourceToSinkDirection ||
                                           x.SourceId.Equals(newNeighborship.SinkId) &&
                                           x.FromSourceToSinkDirection == newNeighborship.FromSinkToSourceDirection) != 0;

            if (neighborAlreadyExists) return false;

            _Neighborships.Add(newNeighborship);
            return true;
        }

        public int Enter(IAvatar avatar)
        {
            GetRoom(DefaultRoomId).Enter(avatar);
            return DefaultRoomId;
        }

        public void ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction)
        {
            int newRoomId;

            var requestedNeighborship = _Neighborships.Find(x => x.SourceId == currentRoomId && x.FromSourceToSinkDirection == direction);

            if (requestedNeighborship != null)
            {
                newRoomId = requestedNeighborship.SinkId;
            }
            else
            {
                requestedNeighborship = _Neighborships.Find(x => x.SinkId == currentRoomId && x.FromSinkToSourceDirection == direction);

                if (requestedNeighborship != null)
                {
                    newRoomId = requestedNeighborship.SourceId;
                }
                else
                {
                    // TODO: Send Error to Client
                    throw new NotImplementedException();
                }
            }

            GetRoom(currentRoomId).Leave(avatar);
            GetRoom(newRoomId).Enter(avatar);
        }

        public int RemoveNeighborship(int firstNeighborId, int secondNeighborId)
        {
            //TODO add Direction? removes all neighborships between firsNeighbor and secondNeighbor
            return _Neighborships.RemoveAll(n => n.SourceId == firstNeighborId && n.SinkId == secondNeighborId ||
                                            n.SourceId == secondNeighborId && n.SinkId == firstNeighborId);
        }
    }
}