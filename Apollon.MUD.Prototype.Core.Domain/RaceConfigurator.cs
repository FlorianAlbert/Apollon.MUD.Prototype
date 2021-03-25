using System;
using Apollon.MUD.Prototype.Core.Implementation.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class RaceConfigurator
    {
        private IDungeon ReferenceDungeon { get; set; }
        private IRace RaceToConfigure { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private int DefaultHealthMax { get; set; }
        private int DefaultDamage { get; set; }
        private int DefaultProtection { get; set; }


        public bool SetDungeon(IDungeon dungeon)
        {
            if (dungeon == null) { return false; }
            ReferenceDungeon = dungeon;
            return true;
        }

        public bool SetClass(IRace raceToConfigure)
        {
            if (raceToConfigure == null) { return false; }
            RaceToConfigure = raceToConfigure;
            return true;
        }

        public bool UpdateName(string name)
        {
            if (name == null) { return false; }
            if (ReferenceDungeon.ConfiguredClasses.Exists(x => string.Equals(name, x.Name, StringComparison.CurrentCultureIgnoreCase))) { return false; }
            Name = name;
            return true;
        }

        public bool UpdateDescription(string description)
        {
            if (description == null) { return false; }
            Description = description;
            return Description != RaceToConfigure.Description;
        }

        public bool UpdateHealth(int health)
        {
            DefaultHealthMax = health;
            return DefaultHealthMax != RaceToConfigure.DefaultHealthMax;
        }

        public bool UpdateDamage(int damage)
        {
            DefaultDamage = damage;
            return DefaultDamage != RaceToConfigure.DefaultDamage;
        }

        public bool UpdateProtection(int protection)
        {
            DefaultProtection = protection;
            return DefaultProtection != RaceToConfigure.DefaultProtection;
        }

        public void SaveChanges()
        {
            RaceToConfigure.Name = Name;
            RaceToConfigure.Description = Description;
            RaceToConfigure.DefaultHealthMax = DefaultHealthMax;
            RaceToConfigure.DefaultDamage = DefaultDamage;
            RaceToConfigure.DefaultProtection = DefaultProtection;
        }
    }
}
