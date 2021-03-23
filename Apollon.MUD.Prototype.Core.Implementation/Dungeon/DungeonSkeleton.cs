using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces;

namespace Apollon.MUD.Prototype.Core.Implementation.Dungeon
{
    public class DungeonSkeleton
    {
        protected List<RoomSkeleton> rooms = new List<RoomSkeleton>();
        protected List<Neighborship> neighbors = new List<Neighborship>(); 

        public DungeonSkeleton()
        {
        }

        public RoomSkeleton addRoom()
        {
            //TODO does foreach truely iterate over the index structure of the list? -> found on stackoverflow but I'm not sure
            int nextIndex = 0;
            rooms.Sort((r1, r2) => r1.CompareTo(r2));
            foreach(RoomSkeleton room in rooms)
            {
                if (room.roomID == nextIndex) { nextIndex++; }
                else break;
            }
            RoomSkeleton newRoom = new RoomSkeleton(nextIndex);
            rooms.Add(newRoom);
            return newRoom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns>The room if exist else null.</returns>
        public RoomSkeleton getRoom(int roomID)
        {
            return rooms.Find(r => r.roomID == roomID);
        }

        /// <summary>
        /// Removes the room and all neighborships where it is involed.
        /// </summary>
        /// <param name="room"></param>
        /// <returns>True if a room was removed.</returns>
        public bool removeRoom(RoomSkeleton room)
        {
            neighbors.RemoveAll(n => n.isInvolved(room));
            return rooms.Remove(room);
        }

        public bool addNeighborship(RoomSkeleton source, Directions fromSourceToSink, RoomSkeleton sink)
        {
            Neighborship newNeighborship = new Neighborship(source, fromSourceToSink, sink);

            foreach (Neighborship neighbor in neighbors){
                if (neighbor.source.Equals(newNeighborship.source))
                {
                    if(neighbor.fromSourceToSink == newNeighborship.fromSourceToSink) { return false; }
                }
                else if (neighbor.source.Equals(newNeighborship.sink))
                {
                    if (neighbor.fromSourceToSink == newNeighborship.fromSinkToSource) { return false; }
                }

                if (neighbor.sink.Equals(newNeighborship.source))
                {
                    if (neighbor.fromSinkToSource == newNeighborship.fromSourceToSink) { return false; }
                }
                else if (neighbor.sink.Equals(newNeighborship.sink))
                {
                    if (neighbor.fromSinkToSource == newNeighborship.fromSinkToSource) { return false; }
                }
            }
            neighbors.Add(newNeighborship);
            return true;
        }

        public int removeNeighborship(RoomSkeleton firstNeighbor, RoomSkeleton secondNeighbor)
        {
            //TODO add Direction? removes all neighborships between firsNeighbor and secondNeighbor
            return neighbors.RemoveAll(n => n.source == firstNeighbor && n.sink == secondNeighbor ||
                                        n.source == secondNeighbor && n.sink == firstNeighbor);
        }
    }
}
