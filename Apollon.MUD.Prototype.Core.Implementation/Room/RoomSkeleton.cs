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
        protected string Description = "Please enter a description.";
        // Usage correct?!
        int IRoom.RoomId => roomId;
        private int roomId { get; }
        protected List<IItem> Items { get; set; } = new();
        protected List<INPC> Npcs { get; set; } = new();
        protected List<IAvatar> Avatars { get; } = new();

        

        public RoomSkeleton(int roomId)
        {
            this.roomId = roomId;
        }

        public string GetDiscription() { return Description; }

        public bool SetDiscription(string description)
        {
            if (description.Length < 500) { this.Description = description; return true; }
            return false;
        }

        public int CompareTo(object other)
        {
            if (typeof(IRoom).IsInstanceOfType(other))
            {
                var room = other as IRoom;
                if (roomId == room.RoomId) { return 0; }
                else if (roomId > room.RoomId || other == null) { return 1; }
                else { return -1; }
            }
            throw new ArgumentException("No instance of type IRoom");
        }

        public string Inspect(string aimName)
        {
            throw new NotImplementedException();
        }

        public bool TakeItem(IAvatar avatar, string itemName)
        {
            throw new NotImplementedException();
        }

        public bool Leave(IAvatar avatar)
        {
            return Avatars.Remove(avatar);
        }

        //why enter internal when leave is public aswell
        public bool Enter(IAvatar avatar)
        {
            Avatars.Add(avatar);
            return Avatars.Contains(avatar);

            // TODO: Send Room Description to Client
        }
    }
}
