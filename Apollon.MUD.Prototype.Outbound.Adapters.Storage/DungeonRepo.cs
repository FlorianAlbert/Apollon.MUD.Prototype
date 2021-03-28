using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Domain;

namespace Apollon.MUD.Prototype.Outbound.Adapters.Storage
{
    public class DungeonRepo : IDungeonRepo
    {
        private List<IDungeon> _ActiveDungeons;
        public List<IDungeon> ActiveDungeons
        {
            get
            {
                return _ActiveDungeons ??= new List<IDungeon>();
            }
        }

        public void DoSpecialAction(int currentDungeonId, int currentRoomId, IAvatar avatar, string action)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).DoSpecialAction(avatar, action);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).DoSpecialAction(avatar, action);
        }

        public void Inspect(int currentDungeonId, int currentRoomId, IAvatar avatar, string aimName)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).Inspect(avatar, aimName);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).Inspect(avatar, aimName);
        }

        public void LeaveDungeon(int currentDungeonId, int currentRoomId, IAvatar avatar)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).Leave(avatar);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).Leave(avatar);
        }

        public void TakeItem(int currentDungeonId, int currentRoomId, IAvatar avatar, string itemName)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).TakeItem(avatar, itemName);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).TakeItem(avatar, itemName);
        }

        public void ChangeRoom(int currentDungeonId, int currentRoomId, IAvatar avatar, EDirections direction)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.ChangeRoom(currentRoomId, avatar, direction);
            DungeonMockData.Dungeon.ChangeRoom(currentRoomId, avatar, direction);
        }

        public void DoSpecialAction(int currentRoomId, IAvatar avatar, string action)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).DoSpecialAction(avatar, action);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).DoSpecialAction(avatar, action);
        }

        public void Inspect(int currentRoomId, IAvatar avatar, string aimName)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).Inspect(avatar, aimName);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).Inspect(avatar, aimName);
        }

        public void LeaveDungeon(int currentRoomId, IAvatar avatar)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).Leave(avatar);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).Leave(avatar);
        }

        public void TakeItem(int currentRoomId, IAvatar avatar, string itemName)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.GetRoom(currentRoomId).TakeItem(avatar, itemName);
            DungeonMockData.Dungeon.GetRoom(currentRoomId).TakeItem(avatar, itemName);
        }

        public int ChangeRoom(int currentRoomId, IAvatar avatar, EDirections direction)
        {
            //ActiveDungeons.Find(x => x.DungeonId == currentDungeonId)?.ChangeRoom(currentRoomId, avatar, direction);
            return DungeonMockData.Dungeon.ChangeRoom(currentRoomId, avatar, direction);
        }

        public void AddDungeon(IDungeon dungeon)
        {
            ActiveDungeons.Add(dungeon);
        }

        public void RemoveDungeon(int dungeonId)
        {
            ActiveDungeons.RemoveAll(x => x.DungeonId == dungeonId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dungeonId">Id of the dungeon to enter</param>
        /// <param name="avatar">Avatar which enters</param>
        /// <returns>Room Number of the start room</returns>
        public int? EnterDungeon(int dungeonId, IAvatar avatar)
        {
            //var roomId = ActiveDungeons.Find(x => x.DungeonId == dungeonId)?.Enter(avatar);
            var roomId = DungeonMockData.Dungeon.Enter(avatar);

            return roomId;
        }

        public int? EnterMockDungeon(IAvatar avatar)
        {
            //var roomId = ActiveDungeons.Find(x => x.DungeonId == dungeonId)?.Enter(avatar);
            var roomId = DungeonMockData.Dungeon.Enter(avatar);

            return roomId;
        }
    }
}
