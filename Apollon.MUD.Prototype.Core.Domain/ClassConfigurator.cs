using System;
using Apollon.MUD.Prototype.Core.Implementation.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ClassConfigurator
    {
        private IDungeon ReferenceDungeon { get; set; }
        private IClass ClassToConfigure { get; set; }
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

        public bool SetClass(IClass classToConfigure)
        {
            if(classToConfigure == null) { return false; }
            ClassToConfigure = classToConfigure;
            return true;
        }

        public bool UpdateName(string name)
        {
            if(name == null) { return false; }
            if (ReferenceDungeon.ConfiguredClasses.Exists(x => string.Equals(name, x.Name, StringComparison.CurrentCultureIgnoreCase))) { return false; }
            Name = name;
            return true;
        }

        public bool UpdateDescription(string description)
        {
            if (description == null) { return false; }
            Description = description;
            return Description != ClassToConfigure.Description;
        }

        public bool UpdateHealth(int health)
        {
            DefaultHealthMax = health;
            return DefaultHealthMax != ClassToConfigure.DefaultHealthMax;
        }

        public bool UpdateDamage(int damage)
        {
            DefaultDamage = damage;
            return DefaultDamage != ClassToConfigure.DefaultDamage;
        }

        public bool UpdateProtection(int protection)
        {
            DefaultProtection = protection;
            return DefaultProtection != ClassToConfigure.DefaultProtection;
        }

        public void SaveChanges()
        {
            ClassToConfigure.Name = Name;
            ClassToConfigure.Description = Description;
            ClassToConfigure.DefaultHealthMax = DefaultHealthMax;
            ClassToConfigure.DefaultDamage = DefaultDamage;
            ClassToConfigure.DefaultProtection = DefaultProtection;
        }
    }
}
