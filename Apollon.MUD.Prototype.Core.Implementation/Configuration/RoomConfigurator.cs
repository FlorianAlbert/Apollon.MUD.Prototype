using System;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration
{
    public class RoomConfigurator
    {
        //Access RoomConfigurator within IDungeon? Or will it be accessed in a differend location?

        private static int _MaxDescriptionLength = 2048;

        private IRoom RoomToConfigure { get; set; }
        private IRoom ConfiguredRoom { get; set; }

        public void SetRoom(IRoom roomToConfigure)
        {
            RoomToConfigure = roomToConfigure;
            ConfiguredRoom = new RoomSkeleton(RoomToConfigure.RoomId);
            ConfiguredRoom.Inspectables.AddRange(roomToConfigure.Inspectables);
            ConfiguredRoom.Description = RoomToConfigure.Description;
        }

        
        public bool PlaceInspectable (IInspectable inspectable)
        {
            if (ConfiguredRoom == null) { return false; }
            ConfiguredRoom.Inspectables.Add(inspectable);
            return ConfiguredRoom.Inspectables.Contains(inspectable);
        }

        public int RemoveInspectable (string aimName)
        {
            if (ConfiguredRoom == null || ConfiguredRoom.RoomId != RoomToConfigure.RoomId) { return 0; }
            return ConfiguredRoom.Inspectables.RemoveAll(x => x.Name == aimName);
        }

        public bool UpdateDescription (string Description)
        {
            if (ConfiguredRoom == null || ConfiguredRoom.RoomId != RoomToConfigure.RoomId) { return false; }
            if (_MaxDescriptionLength >= Description.Length) { ConfiguredRoom.Description = Description; }
            return !(ConfiguredRoom.Description == RoomToConfigure.Description);
        }

        public bool SaveChanges()
        {
            if(ConfiguredRoom == null || ConfiguredRoom.RoomId != RoomToConfigure.RoomId) { return false; }
            RoomToConfigure.Inspectables = ConfiguredRoom.Inspectables;
            RoomToConfigure.Description = ConfiguredRoom.Description;
            ConfiguredRoom = null;
            return true;
        }

    }
}
