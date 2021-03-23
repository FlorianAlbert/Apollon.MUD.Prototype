using Apollon.MUD.Prototype.Core.Implementation.Dungeon;
using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Outbound.Adapters.Storage
{
    public class DungeonRepo : IDungeonRepo
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        private List<DungeonSkeleton> ActiveDungeons { get; }

        public DungeonRepo(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public void DoSpecialAction(int currentDungeonId, int currentRoomId, string action)
        {
            throw new NotImplementedException();
        }

        public void Inspect(int currentDungeonId, int currentRoomId, string aimName)
        {
            ActiveDungeons.Find(x => x.DungeonId == currentDungeonId).GetRoom(currentRoomId).Inspect(aimName);
        }

        public void LeaveDungeon(int currentDungeonId, int currentRoomId, IAvatar avatar)
        {
            ActiveDungeons.Find(x => x.DungeonId == currentDungeonId).GetRoom(currentRoomId).Leave(avatar);
        }

        public void TakeItem(int currentDungeonId, int currentRoomId, IAvatar avatar, string itemName)
        {
            ActiveDungeons.Find(x => x.DungeonId == currentDungeonId).GetRoom(currentRoomId).TakeItem(avatar, itemName);
        }

        public void ChangeRoom(int currentDungeonId, int currentRoomId, IAvatar avatar, EDirections direction)
        {
            ActiveDungeons.Find(x => x.DungeonId == currentDungeonId).ChangeRoom(currentRoomId, avatar, direction);
        }

        public void AddDungeon(DungeonSkeleton dungeon)
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
        public int EnterDungeon(int dungeonId, IAvatar avatar)
        {
            var roomId = ActiveDungeons.Find(x => x.DungeonId == dungeonId).Enter(avatar);
            return roomId;
        }
    }
}
