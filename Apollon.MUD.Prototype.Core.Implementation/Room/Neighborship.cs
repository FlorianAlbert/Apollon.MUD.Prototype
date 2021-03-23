using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class Neighborship
    {
        public int SourceId { get; }
        public EDirections fromSourceToSink { get; }
        public int SinkId { get; }
        public EDirections fromSinkToSource{ get; }

        public Neighborship(int sourceId, EDirections fromSourceToSink, int sinkId)
        {
            this.SourceId = sourceId;
            this.fromSourceToSink = fromSourceToSink;
            this.SinkId = sinkId;
            fromSinkToSource = (EDirections) ((int) (fromSourceToSink + 2) % 4);
        }

        public bool isInvolved(int roomId)
        {
            return SourceId == roomId || SinkId == roomId;
        }
    }
}
