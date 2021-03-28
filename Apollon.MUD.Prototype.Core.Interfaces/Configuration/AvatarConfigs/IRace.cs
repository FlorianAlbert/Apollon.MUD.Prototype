using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs
{
    public interface IRace
    {
        string Name { get; }
        string Description { get; }
        int DefaultHealthMax { get; }
        int DefaultDamage { get; }
        int DefaultProtection { get; }
    }
}
