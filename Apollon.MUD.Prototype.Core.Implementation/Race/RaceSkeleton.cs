using System;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Implementation.Race
{
    public class RaceSkeleton : IRace
    {
        public string Name { get; }
        public int DefaultHealthMax { get; }
        public int DefaultDamage { get; }
        public int DefaultProtection { get; }

        private RaceSkeleton(string Name, int DefaultHealthMax, int DefaultDamage, int DefaultProtection)
        {
            this.Name = Name;
            this.DefaultHealthMax = DefaultHealthMax;
            this.DefaultDamage = DefaultDamage;
            this.DefaultProtection = DefaultProtection;
        }

        public class RaceBuilder
        {
            private string Name;
            private int DefaultHealthMax;
            private int DefaultDamage;
            private int DefaultProtection;

            public RaceSkeleton build()
            {
                return new RaceSkeleton(Name, DefaultHealthMax, DefaultDamage, DefaultProtection);
            }

            public RaceBuilder setName(string name)
            {
                Name = name;
                return this;
            }

            public RaceBuilder setDefaultHealth(int defaultHealthMax)
            {
                DefaultHealthMax = defaultHealthMax;
                return this;
            }

            public RaceBuilder setDefaultDamage(int defaultDamage)
            {
                DefaultDamage = defaultDamage;
                return this;
            }

            public RaceBuilder setDefaultProtection(int defaultProtection)
            {
                DefaultProtection = defaultProtection;
                return this;
            }
        }
    }
}
