using System;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Implementation.Class
{
    public class ClassSkeleton : IClass
    {
        public string Name { get; }
        public string Description { get;  }
        public int DefaultHealthMax { get; }
        public int DefaultDamage { get; }
        public int DefaultProtection { get; }

        private ClassSkeleton(string Name, string Description, int DefaultHealthMax, int DefaultDamage, int DefaultProtection)
        {
            this.Name = Name;
            this.Description = Description;
            this.DefaultHealthMax = DefaultHealthMax;
            this.DefaultDamage = DefaultDamage;
            this.DefaultProtection = DefaultProtection;
        }

        public class ClassBuilder
        {
            private string Name = "Please enter a name.";
            private string Description = "Please enter a description.";
            private int DefaultHealthMax = 0;
            private int DefaultDamage = 0;
            private int DefaultProtection = 0;

            public ClassSkeleton build()
            {
                return new ClassSkeleton(Name, Description, DefaultHealthMax, DefaultDamage, DefaultProtection);
            }

            public ClassBuilder setName(string name)
            {
                if (name == null) { throw new ArgumentNullException("The name was null."); }
                Name = name;
                return this;
            }

            public ClassBuilder setDescription(string description)
            {
                if (description == null) { throw new ArgumentNullException("The description was null."); }
                Description = description;
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
