using System;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Interface.Configuration.AvatarConfigs
{
    public class ClassSkeleton : IClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefaultHealthMax { get; set; }
        public int DefaultDamage { get; set; }
        public int DefaultProtection { get; set; }

        public ClassSkeleton(string Name, string Description = "", int DefaultHealthMax = 0, int DefaultDamage = 0, int DefaultProtection = 0)
        {
            this.Name = Name;
            this.Description = Description;
            this.DefaultHealthMax = DefaultHealthMax;
            this.DefaultDamage = DefaultDamage;
            this.DefaultProtection = DefaultProtection;
        }
    }
}
