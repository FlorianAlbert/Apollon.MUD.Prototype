using System;
using Apollon.MUD.Prototype.Core.Implementation.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class DungeonConfigurator
    {
        //TODO connection to UI => listener? and response

        private IDungeon DungeonToConfigur { get; set; }
        private IDungeon ConfiguredDungeon { get; set; }
        private bool _NewDungeon { get; set; } = false;

        public bool SetDungeon(IDungeon dungeon)
        {
            if(dungeon == null) { return false; }
            DungeonToConfigur = dungeon;
            ConfiguredDungeon.ConfiguredClasses.AddRange(DungeonToConfigur.ConfiguredClasses);
            ConfiguredDungeon.ConfiguredRaces.AddRange(DungeonToConfigur.ConfiguredRaces);
            ConfiguredDungeon.Rooms.AddRange(DungeonToConfigur.Rooms);
            ConfiguredDungeon.Neighborships.AddRange(DungeonToConfigur.Neighborships);
            return true;
        }

        public bool NewDungeon(string epoch)
        {
            if(epoch == null) { return false; }
            DungeonToConfigur = new DungeonSkeleton(epoch);
            _NewDungeon = true;
            return true;
        }

         

        public void SaveDungeon()
        {
            if (_NewDungeon)
            {
                //TODO save Dungeon into DungeonRepo
                throw new NotImplementedException();
            }
            DungeonToConfigur.ConfiguredClasses.Clear();
            DungeonToConfigur.ConfiguredClasses.AddRange(ConfiguredDungeon.ConfiguredClasses);
            DungeonToConfigur.ConfiguredRaces.Clear();
            DungeonToConfigur.ConfiguredRaces.AddRange(ConfiguredDungeon.ConfiguredRaces);
            DungeonToConfigur.Rooms.Clear();
            DungeonToConfigur.Rooms.AddRange(ConfiguredDungeon.Rooms);
            DungeonToConfigur.Neighborships.Clear();
            DungeonToConfigur.Neighborships.AddRange(ConfiguredDungeon.Neighborships);
        }
    }
}
