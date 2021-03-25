using System;
using Apollon.MUD.Prototype.Core.Implementation.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class DungeonConfigurator
    {
        //TODO connection to UI => listener? and response
        //TODO add ItemConfigurator

        private IDungeon DungeonToConfigur { get; set; }
        private IDungeon ConfiguredDungeon { get; set; }
        private RaceConfigurator RaceConfigurator { get; set; }
        private ClassConfigurator ClassConfigurator { get; set; }
        private RoomConfigurator RoomConfigurator { get; set; }
        private bool IsNewDungeon { get; set; } = false;

        public bool LoadDungeon(IDungeon dungeon)
        {
            if(dungeon == null) { return false; }
            DungeonToConfigur = dungeon;
            ConfiguredDungeon.ConfiguredClasses.AddRange(DungeonToConfigur.ConfiguredClasses);
            ConfiguredDungeon.ConfiguredRaces.AddRange(DungeonToConfigur.ConfiguredRaces);
            ConfiguredDungeon.Rooms.AddRange(DungeonToConfigur.Rooms);
            ConfiguredDungeon.Neighborships.AddRange(DungeonToConfigur.Neighborships);
            SetUpConfigurators();
            return true;
        }

        public bool NewDungeon(string epoch)
        {
            if(epoch == null) { return false; }
            DungeonToConfigur = new DungeonSkeleton(epoch);
            IsNewDungeon = true;
            SetUpConfigurators();
            return true;
        }

         

        public void SaveDungeon()
        {
            if (IsNewDungeon)
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

        public RaceConfigurator ConfigureRace() { return RaceConfigurator; }

        public ClassConfigurator ConfigureClass() { return ClassConfigurator; }

        public RoomConfigurator ConfigureRoom() { return RoomConfigurator;  }

        private void SetUpConfigurators()
        {
            RaceConfigurator = new RaceConfigurator(ConfiguredDungeon);
            ClassConfigurator = new ClassConfigurator(ConfiguredDungeon);
            RoomConfigurator = new RoomConfigurator();
        }
    }
}
