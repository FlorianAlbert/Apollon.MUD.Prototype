using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interface.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Outbound.Ports.Storage
{
    public interface IDungeonRepo
    {
        List<IDungeon> ActiveDungeons { get; }

        void DoSpecialAction(int currentDungeonId, int currentRoomId, IAvatar avatar, string action);

        void Inspect(int currentDungeonId, int currentRoomId, IAvatar avatar, string aimName);

        void LeaveDungeon(int currentDungeonId, int currentRoomId, IAvatar avatar);

        void TakeItem(int currentDungeonId, int currentRoomId, IAvatar avatar, string itemName);

        void ChangeRoom(int currentDungeonId, int currentRoomId, IAvatar avatar, EDirections direction);

        void AddDungeon(IDungeon dungeon);

        void RemoveDungeon(int dungeonId);

        int? EnterDungeon(int dungeonId, IAvatar avatar);
    }
}
