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
        
        public int RoomId => roomId;
        protected int roomId { get; }
        public string Discription => discription;
        protected string discription = "Please enter a description.";
        public List<IItem> Items => items;
        protected List<IItem> items { get; set; } = new();
        public List<INPC> Npcs => npcs;
        protected List<INPC> npcs { get; set; } = new();
        public List<IAvatar> Avatars => avatars;
        protected List<IAvatar> avatars { get; } = new();

        public RoomSkeleton(int roomId)
        {
            this.roomId = roomId;
        }

        public bool SetDiscription(string discription)
        {
            if (discription.Length < 500) { this.discription = discription; return true; }
            return false;
        }

        public int CompareTo(object other)
        {
            if (typeof(IRoom).IsInstanceOfType(other) && other != null)
            {
                var room = other as IRoom;
                if (roomId == room.RoomId) { return 0; }
                if (roomId > room.RoomId) { return 1; }
            }
            return -1;
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
            return avatars.Remove(avatar);
        }

        //why enter internal when leave is public aswell
        public bool Enter(IAvatar avatar)
        {
            avatars.Add(avatar);
            return avatars.Contains(avatar);

            // TODO: Send Room Description to Client
        }
    }
}
