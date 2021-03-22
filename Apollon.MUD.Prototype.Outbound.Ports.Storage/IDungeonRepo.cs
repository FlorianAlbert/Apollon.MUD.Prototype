using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Outbound.Ports.Storage
{
    public interface IDungeonRepo
    {
        void EnterDungeon(int dungeonId);

        void LeaveDungeon();

        void ChangeRoom(Direction direction);

        void TakeItem(string itemName);

        void Inspect(string aimName);

        void DoSpecialAction(string action);
    }
}
