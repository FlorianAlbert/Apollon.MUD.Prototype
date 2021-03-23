using Apollon.MUD.Prototype.Core.Implementation.Direction;
using Apollon.MUD.Prototype.Core.Implementation.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Outbound.Ports.Storage
{
    public interface IDungeonRepo
    {
        void DoSpecialAction(int currentDungeonId, int currentRoomId, string action);

        void Inspect(int currentDungeonId, int currentRoomId, string aimName);

        void LeaveDungeon(int currentDungeonId, int currentRoomId, IAvatar avatar);

        void TakeItem(int currentDungeonId, int currentRoomId, IAvatar avatar, string itemName);

        void ChangeRoom(int currentDungeonId, int currentRoomId, IAvatar avatar, Directions direction);

        void AddDungeon(DungeonSkeleton dungeon);

        void RemoveDungeon(int dungeonId);

        int EnterDungeon(int dungeonId, IAvatar avatar);
    }
}
