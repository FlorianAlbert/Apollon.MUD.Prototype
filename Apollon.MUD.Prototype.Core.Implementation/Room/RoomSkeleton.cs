using System;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class RoomSkeleton : IRoom
    {
        public string Description { get; set; } = "Please enter a description.";

        public int RoomId { get; set; }
        public List<IInspectable> Inspectables { get; set; } = new();
        public List<EDirections> DirectionsToNeigbors { get; init; } = new();

        public RoomSkeleton(int roomId, string roomDescription)
        {
            RoomId = roomId;
            Description = roomDescription;
        }
        
        public RoomSkeleton(int roomId)
        {
            RoomId = roomId;
            Description = "No Description given";
        }

        public int CompareTo(IRoom other)
        {
            if (other == null) return 1;
            return RoomId.CompareTo(other.RoomId);
        }

        public void Inspect(IAvatar avatar, string aimName)
        {
            var toInspect = Inspectables.Find(x => string.Equals(aimName, x.Name, StringComparison.CurrentCultureIgnoreCase));
            if(string.Equals(aimName, toInspect.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                avatar.SendPrivateMessage(toInspect.Description);
            }
            else
            {
                avatar.SendPrivateMessage("Es gibt hier nichts zu untersuchen mit dem Namen " + toInspect.Name + " .");
            }

        }

        public bool TakeItem(IAvatar avatar, string itemName)
        {
            var item = Inspectables.Find(x => string.Equals(itemName, x.Name, StringComparison.CurrentCultureIgnoreCase));

            if (item is ITakeable takeableItem)
            {
                avatar.AddItemToInventory(takeableItem);
                return Inspectables.Remove(takeableItem);
            } 
            avatar.SendPrivateMessage("Wie willst du das denn mit dir schleppen?!");
            return false;
        }

        public bool Leave(IAvatar avatar)
        {
            return Inspectables.Remove(avatar);
        }
        
        public bool Enter(IAvatar avatar)
        {
            Inspectables.Add(avatar);
            InspectRoom(avatar);
            // TODO: Send Room Description to Client
            return Inspectables.Contains(avatar);

        }

        public bool TalkToNpc(IAvatar avatar, string aimName)
        {
            var item = Inspectables.Find(x => x.Name == aimName);

            if (item is INPC npc)
            {
                avatar.SendPrivateMessage(npc.Speak());
            }
            else
            {
                //gib error aus
            }
            throw new NotImplementedException();
        }

        public void DoSpecialAction(IAvatar avatar, string action)
        {
            throw new NotImplementedException();
        }

        public void InspectRoom(IAvatar avatar)
        {
            var description = Description;
            foreach(var inspectable in Inspectables)
            {
                description += "\n" + inspectable.Name;
            }
            description += "\nAusgänge:";
            if (DirectionsToNeigbors.Contains(EDirections.NORTH)) description += "\nNORDEN";
            if (DirectionsToNeigbors.Contains(EDirections.SOUTH)) description += "\nSUEDEN";
            if (DirectionsToNeigbors.Contains(EDirections.EAST)) description += "\nOSTEN";
            if (DirectionsToNeigbors.Contains(EDirections.WEST)) description += "\nWESTEN";
            avatar.SendPrivateMessage(description);
        }

        public void InspectRoom(IAvatar avatar, string exitDirections)
        {
            throw new NotImplementedException();
        }
    }
}
