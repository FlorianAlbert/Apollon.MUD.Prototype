using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Implementation.Item;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interface.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interface.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Direction;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public static class DungeonMockData
    {
        static int dungeonId = 1;
        static string dungeonDescription = "Dies ist ein vordefiniertes Mock-Dungeon, welches die Benutzung eines Dungeons näher beleuten soll.";
        static string dungeonEpoch = "Mittelalter";
        static IRace Orks = new RaceSkeleton("Ork", "Okrs sind schlimme Wesen.", 50, 20, 10);
        static IRace Elfen = new RaceSkeleton("Elf", "Elfen sind tolle Wesen.", 40, 10, 30);
        static List<IRace> configuredRaces = new List<IRace> { Orks, Elfen};
        static IClass Berserker = new ClassSkeleton("Berserker", "Bererker sind stake Krieger.", 50, 30, 10);
        static IClass Magier = new ClassSkeleton("Magier", "Magier haben ein langes Durchhaltevermögen.", 60, 10, 40);
        static List<IClass> configuredClasses = new List<IClass> { Berserker, Magier };
        static IInspectable Baum = new Inspectable("Baum", "Dies ist ein großer Baum");
        static IInspectable Busch = new Inspectable("Busch", "In dem Busch raschelt es.");
        static Takeable Flasche = new Takeable("Flasche", "Diese Flasche ist leer.", 2);
        static Takeable Stab = new Takeable("Stab", "Dies ist ein sonderbarer Stab.", 1);
        static List<IInspectable> configuredInspectables = new List<IInspectable> { Baum, Busch, Flasche, Stab };
        static IRoom Room1 = new RoomSkeleton(0, "Dies ist der erste Raum des Dungeons.")
        {
            Inspectables = new List<IInspectable> { Busch, Baum },
            DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> { EDirections.NORTH}
        };
        static IRoom Room2 = new RoomSkeleton(1, "Dies ist der zweite Raum des Dungeons.")
        {
            Inspectables = new List<IInspectable> { Baum, Flasche },
            DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> { EDirections.NORTH, EDirections.SOUTH, EDirections.EAST, EDirections.WEST }
        };
        static IRoom Room3 = new RoomSkeleton(2, "Dies ist der dritte Raum des Dungeons.")
        {
            Inspectables = new List<IInspectable> { Baum, Stab },
            DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> { EDirections.SOUTH }
        };
        static IRoom Room4 = new RoomSkeleton(3, "Dies ist der vierte Raum des Dungeons.")
        {
            Inspectables = new List<IInspectable> { Baum, Flasche },
            DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> { EDirections.WEST }
        };
        static IRoom Room5 = new RoomSkeleton(4, "Dies ist der fünfte Raum des Dungeons.")
        {
            Inspectables = new List<IInspectable> { Baum, Stab, Flasche },
            DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> { EDirections.EAST }
        };
        static List<IRoom> rooms = new List<IRoom> { Room1, Room2, Room3, Room4, Room5};
        static Neighborship Neighborship1 = new Neighborship(0, EDirections.NORTH, 1);
        static Neighborship Neighborship2 = new Neighborship(1, EDirections.NORTH, 2);
        static Neighborship Neighborship3 = new Neighborship(1, EDirections.EAST, 3);
        static Neighborship Neighborship4 = new Neighborship(1, EDirections.WEST, 4);
        static List<INeighborship> neighborships = new List<INeighborship> { Neighborship1, Neighborship2, Neighborship3, Neighborship4};
        static int defaultRoomId = 0;
        public static IDungeon Dungeon = new DungeonSkeleton(dungeonEpoch)
        {
            DungeonId = dungeonId,
            DungeonDescription = dungeonDescription,
            ConfiguredRaces = configuredRaces,
            ConfiguredClasses = configuredClasses,
            ConfiguredInspectables = configuredInspectables,
            Neighborships = neighborships,
            Rooms = rooms,
            DefaultRoomId = defaultRoomId
    };
    }
}
