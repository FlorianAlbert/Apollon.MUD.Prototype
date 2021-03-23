using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class Neighborship
    {
        public int SourceId { get; }
        public EDirections FromSourceToSinkDirection { get; }
        public int SinkId { get; }
        public EDirections FromSinkToSourceDirection{ get; }

        public Neighborship(int sourceId, EDirections fromSourceToSinkDirection, int sinkId)
        {
            SourceId = sourceId;
            FromSourceToSinkDirection = fromSourceToSinkDirection;
            SinkId = sinkId;
            FromSinkToSourceDirection = (EDirections) ((int) (fromSourceToSinkDirection + 2) % 4);
        }

        public bool IsInvolved(int roomId)
        {
            return SourceId == roomId || SinkId == roomId;
        }
    }
}
