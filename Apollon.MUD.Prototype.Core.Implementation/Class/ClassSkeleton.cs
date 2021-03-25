using System;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Implementation.Class
{
    public class ClassSkeleton : IClass
    {
        public string Name { get; }
        public int DefaultHealthMax { get; }
        public int DefaultDamage { get; }
        public int DefaultProtection { get; }

        private ClassSkeleton(string Name, int DefaultHealthMax, int DefaultDamage, int DefaultProtection)
        {
            this.Name = Name;
            this.DefaultHealthMax = DefaultHealthMax;
            this.DefaultDamage = DefaultDamage;
            this.DefaultProtection = DefaultProtection;
        }

        public class ClassBuilder
        {
            private string Name;
            private int DefaultHealthMax;
            private int DefaultDamage;
            private int DefaultProtection;

            public ClassSkeleton build()
            {
                return new ClassSkeleton(Name, DefaultHealthMax, DefaultDamage, DefaultProtection);
            }

            public ClassBuilder setName(string name)
            {
                Name = name;
                return this;
            }

            public ClassBuilder setDefaultHealth(int defaultHealthMax)
            {
                DefaultHealthMax = defaultHealthMax;
                return this;
            }

            public ClassBuilder setDefaultDamage(int defaultDamage)
            {
                DefaultDamage = defaultDamage;
                return this;
            }

            public ClassBuilder setDefaultProtection(int defaultProtection)
            {
                DefaultProtection = defaultProtection;
                return this;
            }
        }

    }
}
