using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface IRoom : IComparable
    {
        int RoomId { get; }

        string GetDiscription();
        string Inspect(IAvatar avatar, string aimName);
        bool Leave(IAvatar avatar);
        bool SetDiscription(string description);
        bool TakeItem(IAvatar avatar, string itemName);
        bool Enter(IAvatar avatar);
    }
}
