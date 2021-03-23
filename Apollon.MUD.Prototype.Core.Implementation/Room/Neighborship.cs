using System;
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
            switch (fromSourceToSink)
            {
                case Directions.NORTH: fromSinkToSource = Directions.SOUTH; break;
                case Directions.EAST: fromSinkToSource = Directions.WEST; break;
                case Directions.SOUTH: fromSinkToSource = Directions.NORTH; break;
                case Directions.WEST: fromSinkToSource = Directions.EAST; break;
            }
        }

        public bool isInvolved(RoomSkeleton room)
        {
            return source == room || sink == room;
        }
    }
}
