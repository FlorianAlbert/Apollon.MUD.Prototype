using System;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface INeighborship
    {
        int SourceId { get; }
        EDirections FromSourceToSinkDirection { get; }
        int SinkId { get; }
        EDirections FromSinkToSourceDirection { get; }

        bool IsInvolved(int roomId);
    }
}
