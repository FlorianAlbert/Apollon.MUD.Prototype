using System;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class RoomSkeleton : IComparable<RoomSkeleton>
    {
        public string Description = "Please enter a description.";
        public int RoomId { get; }
        public List<IItem> Items { get; set; } = new();
        public List<INPC> Npcs { get; set; } = new();
        public List<IAvatar> Avatars { get; } = new();

        public RoomSkeleton(int roomId)
        {
            RoomId = roomId;
        }

        public string GetDiscription() { return Description; }

        public bool SetDiscription(string description)
        {
            if(description.Length < 500) { this.Description = description; return true; }
            return false;
        }

        public int CompareTo(RoomSkeleton other)
        {
            if (RoomId == other.RoomId) return 0;
            if (RoomId < other.RoomId) return -1;
            return 1;
        }

        public void Inspect(string aimName)
        {
            throw new NotImplementedException();
        }

        public void TakeItem(IAvatar avatar, string itemName)
        {
            throw new NotImplementedException();
        }

        public void Leave(IAvatar avatar)
        {
            Avatars.Remove(avatar);
        }

        internal void Enter(IAvatar avatar)
        {
            Avatars.Add(avatar);

            // TODO: Send Room Description to Client
        }
    }
}
