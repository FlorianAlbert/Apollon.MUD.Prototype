using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface IRoom : IComparable
    {
        int RoomId { get; }
        string Description { get; set; }
        List<IItem> Items { get; }
        List<INPC> Npcs { get; }
        List<IAvatar> Avatars { get; }
        
        string Inspect(IAvatar avatar, string aimName);
        bool Leave(IAvatar avatar);
        bool TakeItem(IAvatar avatar, string itemName);
        bool Enter(IAvatar avatar);
    }
}
