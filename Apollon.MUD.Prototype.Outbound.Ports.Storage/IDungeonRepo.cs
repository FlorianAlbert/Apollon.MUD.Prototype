using Apollon.MUD.Prototype.Core.Implementation.Direction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollon.MUD.Prototype.Core.Implementation.Dungeon;

namespace Apollon.MUD.Prototype.Outbound.Ports.Storage
{
    public interface IDungeonRepo
    {
        void EnterDungeon(int dungeonId);

        void LeaveDungeon();

        void ChangeRoom(Directions direction);

        void TakeItem(string itemName);

        void Inspect(string aimName);

        void DoSpecialAction(string action);

        void AddDungeon(DungeonSkeleton dungeon);

        void RemoveDungeon(int dungeonId);
    }
}
