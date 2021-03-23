using System;
using System.Collections.Generic;
using System.Linq;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Implementation.Dungeon
{
    public class DungeonSkeleton : IDungeon
    {
        protected List<Neighborship> Neighborships = new();
        protected List<IRoom> Rooms = new();

        private int DefaultRoomId { get; set; }

        public int DungeonId { get; }

        public IRoom AddRoom(bool asDefault = false)
        {
            //TODO does foreach truely iterate over the index structure of the list? -> found on stackoverflow but I'm not sure
            var nextIndex = 0;
            Rooms.Sort((r1, r2) => r1.CompareTo(r2));
            foreach (var room in Rooms)
                if (room.RoomId == nextIndex)
                    nextIndex++;
                else break;
            var newRoom = new RoomSkeleton(nextIndex) as IRoom;

            if (asDefault || Rooms.Count == 0) DefaultRoomId = newRoom.RoomId;

            Rooms.Add(newRoom);

            return newRoom;
        }

        /// <summary>
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>The room if exist else null.</returns>
        public RoomSkeleton GetRoom(int roomId)
        {
            return Rooms.Find(r => r.RoomId == roomId);
        }

        public bool RemoveRoom(int RoomId)
        {
            Neighborships.RemoveAll(n => n.isInvolved(RoomId));
            return Rooms.Remove(Rooms.Find(r => r.RoomId == RoomId));
        }

        public bool AddNeighborship(int SourceId, EDirections fromSourceToSink, int SinkId)
        {
            var newNeighborship = new Neighborship(SourceId, fromSourceToSink, SinkId);

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
            GetRoom(DefaultRoomId).Enter(avatar);
            return DefaultRoomId;
        }

        public void ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction)
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
            return Neighborships.RemoveAll(n => n.SourceId == firstNeighborId && n.SinkId == secondNeighborId ||
                                            n.SourceId == secondNeighborId && n.SinkId == firstNeighborId);
        }
    }
}