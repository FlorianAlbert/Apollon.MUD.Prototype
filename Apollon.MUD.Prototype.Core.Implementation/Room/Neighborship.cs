using Apollon.MUD.Prototype.Core.Implementation.Direction;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class Neighborship
    {
        public int SourceId { get; }
        public Directions FromSourceToSinkDirection { get; }
        public int SinkId { get; }
        public Directions FromSinkToSourceDirection{ get; }

        public Neighborship(int sourceId, Directions fromSourceToSinkDirection, int sinkId)
        {
            SourceId = sourceId;
            FromSourceToSinkDirection = fromSourceToSinkDirection;
            SinkId = sinkId;
            FromSinkToSourceDirection = (Directions) ((int) (fromSourceToSinkDirection + 2) % 4);
        }

        public bool IsInvolved(int roomId)
        {
            return SourceId == roomId || SinkId == roomId;
        }
    }
}
