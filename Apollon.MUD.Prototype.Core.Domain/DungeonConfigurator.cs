using System;
using Apollon.MUD.Prototype.Core.Interface.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class DungeonConfigurator
    {
        //TODO add InspectableConfigurator

        private IDungeon DungeonToConfigure { get; set; }
        private IDungeon ConfiguredDungeon { get; set; }
        private RaceConfigurator RaceConfigurator { get; set; }
        private ClassConfigurator ClassConfigurator { get; set; }
        private RoomConfigurator RoomConfigurator { get; set; }
        private bool IsNewDungeon { get; set; } = false;

        public DungeonConfigurator(RaceConfigurator raceConfigurator, ClassConfigurator classConfigurator, RoomConfigurator roomConfigurator)
        {
            RaceConfigurator = raceConfigurator;
            ClassConfigurator = classConfigurator;
            RoomConfigurator = roomConfigurator;
        }

        public bool LoadDungeon(IDungeon dungeon)
        {
            if(dungeon == null) { return false; }
            DungeonToConfigure = dungeon;
            ConfiguredDungeon = new DungeonSkeleton(DungeonToConfigure.DungeonEpoch);
            ConfiguredDungeon.ConfiguredClasses.AddRange(DungeonToConfigure.ConfiguredClasses);
            ConfiguredDungeon.ConfiguredRaces.AddRange(DungeonToConfigure.ConfiguredRaces);
            ConfiguredDungeon.Rooms.AddRange(DungeonToConfigure.Rooms);
            ConfiguredDungeon.Neighborships.AddRange(DungeonToConfigure.Neighborships);
            return true;
        }

        public bool NewDungeon(string epoch)
        {
            if(epoch == null) { return false; }
            DungeonToConfigure = new DungeonSkeleton(epoch);
            ConfiguredDungeon = new DungeonSkeleton(epoch);
            ConfiguredDungeon.ConfiguredClasses.AddRange(DungeonToConfigure.ConfiguredClasses);
            ConfiguredDungeon.ConfiguredRaces.AddRange(DungeonToConfigure.ConfiguredRaces);
            ConfiguredDungeon.Rooms.AddRange(DungeonToConfigure.Rooms);
            ConfiguredDungeon.Neighborships.AddRange(DungeonToConfigure.Neighborships);
            return true;
        }

         

        public IDungeon SaveDungeon()
        {
            DungeonToConfigure.ConfiguredClasses.Clear();
            DungeonToConfigure.ConfiguredClasses.AddRange(ConfiguredDungeon.ConfiguredClasses);
            DungeonToConfigure.ConfiguredRaces.Clear();
            DungeonToConfigure.ConfiguredRaces.AddRange(ConfiguredDungeon.ConfiguredRaces);
            DungeonToConfigure.Rooms.Clear();
            DungeonToConfigure.Rooms.AddRange(ConfiguredDungeon.Rooms);
            DungeonToConfigure.Neighborships.Clear();
            DungeonToConfigure.Neighborships.AddRange(ConfiguredDungeon.Neighborships);
            return DungeonToConfigure;
        }

        public RaceConfigurator ConfigureRace() { return RaceConfigurator.SetDungeon(ConfiguredDungeon); }

        public ClassConfigurator ConfigureClass() { return ClassConfigurator.SetDungeon(ConfiguredDungeon); }

        public RoomConfigurator ConfigureRoom() { return RoomConfigurator;  }

    }
}
