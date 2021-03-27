using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface IRoom : IComparable<IRoom>
    {
        int RoomId { get; }
        string Description { get; set; }
        List<IInspectable> Inspectables { get; set; }
        List<EDirections> DirectionsToNeigbors { get; init; }
        
        void Inspect(IAvatar avatar, string aimName);
        public void InspectRoom(IAvatar avatar);
        bool Leave(IAvatar avatar);
        bool TakeItem(IAvatar avatar, string itemName);
        bool PlaceItem(ITakeable item);
        bool Enter(IAvatar avatar);
        void DoSpecialAction(IAvatar avatar, string action);
    }
}
