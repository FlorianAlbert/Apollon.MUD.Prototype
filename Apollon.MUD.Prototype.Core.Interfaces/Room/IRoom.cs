using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface IRoom : IComparable
    {
        public int RoomId { get; }
        public string Discription { get; }
        public List<IItem> Items { get; }
        public List<INPC> Npcs { get; }
        public List<IAvatar> Avatars { get; }

        public string Inspect(string aimName);
        public bool Leave(IAvatar avatar);
        public bool SetDiscription(string description);
        public bool TakeItem(IAvatar avatar, string itemName);
        public bool Enter(IAvatar avatar);
    }
}
