using System;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class RoomSkeleton : IRoom
    {
        public string Description { get; set; } = "Please enter a description.";

        public int RoomId { get; }
        public List<IInspectable> Inspectables { get; set; } = new();

        public RoomSkeleton(int roomId)
        {
            RoomId = roomId;
        }

        public int CompareTo(object other)
        {
            if (other == null) return 1;

            if (other is IRoom otherRoom) return RoomId.CompareTo(otherRoom.RoomId);
            throw new ArgumentException("Object is not a Room");
        }

        public string Inspect(IAvatar avatar, string aimName)
        {
            throw new NotImplementedException();

        }

        public bool TakeItem(IAvatar avatar, string itemName)
        {
            var item = Inspectables.Find(x => x.Name == itemName);

            if (item is ITakeable takeableItem)
            {
                avatar.AddItemToInventory(takeableItem);
                Inspectables.Remove(takeableItem);
            }
            else
            {
                //gib error aus
            }
            throw new NotImplementedException();
        }

        public bool Leave(IAvatar avatar)
        {
            return Inspectables.Remove(avatar);
        }
        
        public bool Enter(IAvatar avatar)
        {
            Inspectables.Add(avatar);
            //avatar.SendPrivateMessage(Description);
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
    }
}
