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
        protected string Description { get; } = "Please enter a description.";

        // Usage correct?!
        public int RoomId { get; }
        protected List<IItem> Items { get; set; } = new();
        protected List<INPC> Npcs { get; set; } = new();
        protected List<IAvatar> Avatars { get; } = new();

        public RoomSkeleton(int roomId)
        {
            RoomId = roomId;
        }

        public bool SetDiscription(string discription)
        {
            if (discription.Length < 500) { this.discription = discription; return true; }
            return false;
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
            throw new NotImplementedException();
        }

        public bool Leave(IAvatar avatar)
        {
            return avatars.Remove(avatar);
        }
        
        public bool Enter(IAvatar avatar)
        {
            Avatars.Add(avatar);
            // TODO: Send Room Description to Client
            return Avatars.Contains(avatar);

        }
    }
}
