using System;
using Apollon.MUD.Prototype.Core.Implementation.Direction;
using Apollon.MUD.Prototype.Core.Interfaces;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class Neighborship
    {
        public RoomSkeleton source { get; }
        public Directions fromSourceToSink { get; }
        public RoomSkeleton sink { get; }
        public Directions fromSinkToSource{ get; }

        public Neighborship(RoomSkeleton source, Directions fromSourceToSink, RoomSkeleton sink)
        {
            this.source = source;
            this.fromSourceToSink = fromSourceToSink;
            this.sink = sink;
            fromSinkToSource = (Directions) ((int) (fromSourceToSink + 2) % 4);
        }

        public bool isInvolved(RoomSkeleton room)
        {
            return source == room || sink == room;
        }
    }
}
