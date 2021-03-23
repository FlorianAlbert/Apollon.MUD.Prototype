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
        public List<IItem> Items { get; set; } = new List<IItem>();
        public List<INPC> Npcs { get; set; } = new List<INPC>();
        public List<IAvatar> Avatars { get; } = new List<IAvatar>();

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
            if (RoomId == other.RoomId) { return 0; }
            else if (RoomId > other.RoomId || other == null) { return 1; }
            else { return -1; }
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
