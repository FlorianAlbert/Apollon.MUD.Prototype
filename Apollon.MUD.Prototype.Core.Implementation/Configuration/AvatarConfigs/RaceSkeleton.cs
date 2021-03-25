using System;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration.AvatarConfigs
{
    public class RaceSkeleton : IRace
    {
        public string Name { get; }
        public int DefaultHealthMax { get; }
        public int DefaultDamage { get; }
        public int DefaultProtection { get; }
        public string Description { get;  }

        private RaceSkeleton(string Name, string Description, int DefaultHealthMax, int DefaultDamage, int DefaultProtection)
        {
            this.Name = Name;
            this.Description = Description;
            this.DefaultHealthMax = DefaultHealthMax;
            this.DefaultDamage = DefaultDamage;
            this.DefaultProtection = DefaultProtection;
        }

        public class RaceBuilder
        {
            private string Name = "Please enter a name.";
            private string Description = "Please enter a description.";
            private int DefaultHealthMax = 0;
            private int DefaultDamage = 0;
            private int DefaultProtection = 0;

            public RaceSkeleton build()
            {
                return new RaceSkeleton(Name, Description, DefaultHealthMax, DefaultDamage, DefaultProtection);
            }

            public RaceBuilder setName(string name)
            {
                if(name == null) { throw new ArgumentNullException("The name was null."); }
                Name = name;
                return this;
            }

            public RaceBuilder setDescription(string description)
            {
                if (description == null) { throw new ArgumentNullException("The description was null."); }
                Description = description;
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
