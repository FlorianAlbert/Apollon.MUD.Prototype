using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration.AvatarConfigs
{
    public class Class : IClass
    {
        public Class(string className, int classDamage, int classHealth, int classProtection)
        {
            Name = className;
            DefaultHealthMax = classHealth;
            DefaultDamage = classDamage;
            DefaultProtection = classProtection;
        }

        public string Name { get; set; }

        public int DefaultHealthMax { get; set; }

        public int DefaultDamage { get; set; }

        public int DefaultProtection { get; set; }
    }
}
