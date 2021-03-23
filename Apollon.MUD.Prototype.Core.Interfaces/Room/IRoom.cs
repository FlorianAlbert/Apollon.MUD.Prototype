using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Interfaces.Room
{
    public interface IRoom : IComparable
    {
        public int RoomId { get; }

        public string GetDiscription();
        public string Inspect(string aimName);
        public bool Leave(IAvatar avatar);
        public bool SetDiscription(string description);
        public bool TakeItem(IAvatar avatar, string itemName);
        public bool Enter(IAvatar avatar);
    }
}
