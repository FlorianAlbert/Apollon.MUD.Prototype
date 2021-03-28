using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.NPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollon.MUD.Prototype.Core.Interface.NPC
{
    class NPC : INPC
    {
        public NPC(string npcName, string npcDescription)
        {
            Name = npcName;
            Description = npcDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Speak()
        {
            return "I can't talk right now";
        }
    }
}
