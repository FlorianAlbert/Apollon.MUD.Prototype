using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.Dungeon
{
    public interface IDungeon
    {
        public bool newRoom(string discription);
        public bool removeRoom();
    }
}
