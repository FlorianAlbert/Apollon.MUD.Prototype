using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Implementation
{
    public class ClientContext
    {
        private IAvatar Avatar { get; set; }

        private int? _DungeonId;
        private int? DungeonId
        {
            get => _DungeonId;
            set
            {
                _DungeonId = value;
                RoomId = null;
            }
        }

        private int? RoomId { get; set; }
    }
}
