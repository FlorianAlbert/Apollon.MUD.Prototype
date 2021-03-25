﻿using System;
using Apollon.MUD.Prototype.Core.Implementation.Room;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Interfaces.Room;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration
{
    public class RoomConfigurator
    {

        private static int _MaxDescriptionLength = 2048;

        private IRoom RoomToConfigure { get; set; }
        private IRoom ConfiguredRoom { get; set; }

        public RoomConfigurator (IRoom roomToConfigure)
        {
            if(roomToConfigure == null) { throw new ArgumentNullException("The room to configure was null."); }
            RoomToConfigure = roomToConfigure;
            ConfiguredRoom = new RoomSkeleton(RoomToConfigure.RoomId);
            ConfiguredRoom.Inspectables.AddRange(roomToConfigure.Inspectables);
            ConfiguredRoom.Description = RoomToConfigure.Description;
        }
        
        public bool PlaceInspectable (IInspectable inspectable)
        {
            ConfiguredRoom.Inspectables.Add(inspectable);
            return ConfiguredRoom.Inspectables.Contains(inspectable);
        }

        public int RemoveInspectable (string aimName)
        {
            return ConfiguredRoom.Inspectables.RemoveAll(x => x.Name == aimName);
        }

        public bool UpdateDescription (string Description)
        {
            if (_MaxDescriptionLength >= Description.Length) { ConfiguredRoom.Description = Description; }
            return !(ConfiguredRoom.Description == RoomToConfigure.Description);
        }

        public void SaveChanges()
        {
            RoomToConfigure.Inspectables = ConfiguredRoom.Inspectables;
            RoomToConfigure.Description = ConfiguredRoom.Description;
        }

    }
}
