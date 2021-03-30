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
            if(toInspect != null && string.Equals(aimName, toInspect.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                avatar.SendPrivateMessage(toInspect.Description);
            }
            else
            {
                avatar.SendPrivateMessage($"Es gibt hier nichts zu untersuchen mit dem Namen { aimName }.");
            }

        }

        public bool TakeItem(IAvatar avatar, string itemName)
        {
            var item = Inspectables.Find(x => string.Equals(itemName, x.Name, StringComparison.CurrentCultureIgnoreCase));

            if (item == null)
            {
                avatar.SendPrivateMessage($"Was du suchst ist hier nicht zu sehen...");
                return false;
            }

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
            var description = Description + "\n\nRauminhalt:";
            foreach(var inspectable in Inspectables)
            {
                description += "\n\t" + inspectable.Name;
            }
            description += "\n\nAusgänge:";
            if (DirectionsToNeigbors.Contains(EDirections.NORDEN)) description += "\n\tNORDEN";
            if (DirectionsToNeigbors.Contains(EDirections.SÜDEN)) description += "\n\tSUEDEN";
            if (DirectionsToNeigbors.Contains(EDirections.OSTEN)) description += "\n\tOSTEN";
            if (DirectionsToNeigbors.Contains(EDirections.WESTEN)) description += "\n\tWESTEN";
            avatar.SendPrivateMessage(description);
        }


        public bool PlaceItem(ITakeable item)
        {
            if (item == null) { return false; }
            Inspectables.Add(item);
            return true;
        }
    }
}
