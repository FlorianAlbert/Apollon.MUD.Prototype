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
        public static IDungeon Dungeon;

        static DungeonMockData()
        {



            int dungeonId = 1;
            string dungeonDescription =
                "Dies ist ein vordefiniertes Mock-Dungeon, welches die Benutzung eines Dungeons näher beleuten soll.";
            string dungeonEpoch = "Mittelalter";
            IRace Orks = new RaceSkeleton("Ork", "Orks sind schlimme Wesen.", 50, 20, 10);
            IRace Elfen = new RaceSkeleton("Elf", "Elfen sind tolle Wesen.", 40, 10, 30);
            List<IRace> configuredRaces = new List<IRace> {Orks, Elfen};
            IClass Berserker = new ClassSkeleton("Berserker", "Bererker sind stake Krieger.", 50, 30, 10);
            IClass Magier = new ClassSkeleton("Magier", "Magier haben ein langes Durchhaltevermögen.", 60, 10, 40);
            List<IClass> configuredClasses = new List<IClass> {Berserker, Magier};
            IInspectable Baum = new Inspectable("Baum", "Dies ist ein großer Baum");
            IInspectable Busch = new Inspectable("Busch", "In dem Busch raschelt es.");
            Consumable Flasche = new Consumable("Flasche", "Diese Flasche ist voller Alkohol.", "Du freust dich über den Erfolg des Prototyps von Team Apollon!", 1);
            Takeable Stab = new Takeable("Stab", "Dies ist ein sonderbarer Stab.", 1);
            List<IInspectable> configuredInspectables = new List<IInspectable> {Baum, Busch, Flasche, Stab};
            IRoom Room1 = new RoomSkeleton(0, "Dies ist der erste Raum des Dungeons.")
            {
                Inspectables = new List<IInspectable> {Busch, Baum},
                DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> {EDirections.NORDEN}
            };
            IRoom Room2 = new RoomSkeleton(1, "Dies ist der zweite Raum des Dungeons.")
            {
                Inspectables = new List<IInspectable> {Baum, Flasche},
                DirectionsToNeigbors = new List<Interfaces.Direction.EDirections>
                    {EDirections.NORDEN, EDirections.SÜDEN, EDirections.OSTEN, EDirections.WESTEN}
            };
            IRoom Room3 = new RoomSkeleton(2, "Dies ist der dritte Raum des Dungeons.")
            {
                Inspectables = new List<IInspectable> {Baum, Stab},
                DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> {EDirections.SÜDEN}
            };
            IRoom Room4 = new RoomSkeleton(3, "Dies ist der vierte Raum des Dungeons.")
            {
                Inspectables = new List<IInspectable> {Baum, Flasche},
                DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> {EDirections.WESTEN}
            };
            IRoom Room5 = new RoomSkeleton(4, "Dies ist der fünfte Raum des Dungeons.")
            {
                Inspectables = new List<IInspectable> {Baum, Stab, Flasche},
                DirectionsToNeigbors = new List<Interfaces.Direction.EDirections> {EDirections.OSTEN}
            };
            List<IRoom> rooms = new List<IRoom> {Room1, Room2, Room3, Room4, Room5};
            Neighborship Neighborship1 = new Neighborship(0, EDirections.NORDEN, 1);
            Neighborship Neighborship2 = new Neighborship(1, EDirections.NORDEN, 2);
            Neighborship Neighborship3 = new Neighborship(1, EDirections.OSTEN, 3);
            Neighborship Neighborship4 = new Neighborship(1, EDirections.WESTEN, 4);
            List<INeighborship> neighborships = new List<INeighborship>
                {Neighborship1, Neighborship2, Neighborship3, Neighborship4};
            int defaultRoomId = 0;
            Dungeon = new DungeonSkeleton(dungeonEpoch)
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
}
