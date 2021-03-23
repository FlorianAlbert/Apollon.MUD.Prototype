using Apollon.MUD.Prototype.Core.Implementation.Direction;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class Neighborship
    {
        public int SourceId { get; }
        public Directions fromSourceToSink { get; }
        public int SinkId { get; }
        public Directions fromSinkToSource{ get; }

        public Neighborship(int sourceId, Directions fromSourceToSink, int sinkId)
        {
            this.SourceId = sourceId;
            this.fromSourceToSink = fromSourceToSink;
            this.SinkId = sinkId;
            fromSinkToSource = (Directions) ((int) (fromSourceToSink + 2) % 4);
        }

        public bool isInvolved(int roomId)
        {
            return SourceId == roomId || SinkId == roomId;
        }
    }
}
