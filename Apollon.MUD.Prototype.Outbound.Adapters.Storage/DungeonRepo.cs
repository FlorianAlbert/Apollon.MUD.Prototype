using Apollon.MUD.Prototype.Outbound.Ports.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Outbound.Adapters.Storage
{
    public class DungeonRepo : IDungeonRepo
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        public DungeonRepo(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public void ChangeRoom(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void DoSpecialAction(string action)
        {
            throw new NotImplementedException();
        }

        public void EnterDungeon(int dungeonId)
        {
            throw new NotImplementedException();
        }

        public void Inspect(string aimName)
        {
            throw new NotImplementedException();
        }

        public void LeaveDungeon()
        {
            throw new NotImplementedException();
        }

        public void TakeItem(string itemName)
        {
            throw new NotImplementedException();
        }
    }
}
