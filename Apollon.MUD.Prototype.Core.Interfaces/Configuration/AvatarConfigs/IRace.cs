using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs
{
    public interface IRace
    {
        string Name { get; set; }
        string Description { get; set; }
        int DefaultHealthMax { get; set; }
        int DefaultDamage { get; set; }
        int DefaultProtection { get; set; }
    }
}
