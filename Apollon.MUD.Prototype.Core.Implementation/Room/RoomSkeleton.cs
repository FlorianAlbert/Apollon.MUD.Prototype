using System;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;

namespace Apollon.MUD.Prototype.Core.Implementation.Room
{
    public class RoomSkeleton : IComparable<RoomSkeleton>
    {
        public string discription = "Please enter a discription.";
        public int roomID { get; }
        public List<IItem> items { get; set; } = new List<IItem>();
        public List<INPC> npcs { get; set; } = new List<INPC>();

        public RoomSkeleton(int roomID)
        {
            this.roomID = roomID;
        }

        public string getDiscription() { return discription; }

        public bool setDiscription(string discription)
        {
            if(discription.Length < 500) { this.discription = discription; return true; }
            return false;
        }

        public int CompareTo(RoomSkeleton other)
        {
            if (roomID == other.roomID) { return 0; }
            else if (roomID > other.roomID || other == null) { return 1; }
            else { return -1; }
        }
    }
}
