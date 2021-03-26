using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interface.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public static class DungeonMockData
    {
        static int DungeonId = 1;
        static string DungeonDescription;
        static string DungeonEpoch = "Mittelalter";
        static List<IRace> ConfiguredRaces;
        static List<IClass> ConfiguredClasses;
        static List<IInspectable> ConfiguredInspectables;
        static List<INeighborship> Neighborships;
        static List<IRoom> Rooms;
        static int DefaultRoomId;
        public static IDungeon Dungeon = new DungeonSkeleton { };
    }
}
