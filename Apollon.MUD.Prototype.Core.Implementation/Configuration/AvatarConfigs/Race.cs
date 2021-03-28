using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration.AvatarConfigs
{
    public class Race : IRace
    {
        public Race(string raceName, string raceDesc, int raceDamage, int raceHealth, int raceProt)
        {
            Name = raceName;
            Description = raceDesc;
            DefaultHealthMax = raceDamage;
            DefaultDamage = raceDamage;
            DefaultProtection = raceProt;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DefaultHealthMax { get; set; }

        public int DefaultDamage { get; set; }

        public int DefaultProtection { get; set; }
    }
}
