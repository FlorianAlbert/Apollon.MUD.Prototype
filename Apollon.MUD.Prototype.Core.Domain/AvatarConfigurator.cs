using System;
using System.Collections.Generic;
using System.Linq;
using Apollon.MUD.Prototype.Core.Implementation.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class AvatarConfigurator
    {
        private IDungeon ReferenceDungeon { get; set; }

        private string AvatarName { get; set; }

        private IRace AvatarRace { get; set; }

        private IClass AvatarClass { get; set; }

        public void SetDungeon(IDungeon dungeon)
        {
            ReferenceDungeon = dungeon;
        }

        public void SetName(string name)
        {
            if (ReferenceDungeon != null)
            {
                if (!ReferenceDungeon.AllAvatars.Exists(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    AvatarName = name;
                }
                else
                {
                    //TODO: send error to client
                }
            }
            else
            {
                //TODO: send error to client
            }
        }

        public bool SetRace(string raceName)
        {
            if (ReferenceDungeon == null) return false;
            if (!ReferenceDungeon.ConfiguredRaces.Exists(x =>
                string.Equals(x.Name, raceName, StringComparison.CurrentCultureIgnoreCase))) return false;
            
            AvatarRace = ReferenceDungeon.ConfiguredRaces.Find(x => string.Equals(x.Name, raceName, StringComparison.CurrentCultureIgnoreCase));

            return true;
            

        }

        public List<string> GetRaceNames()
        {
            return ReferenceDungeon.ConfiguredRaces.Select(x => x.Name).ToList();
        }

        public List<string> GetClassNames()
        {
            return ReferenceDungeon.ConfiguredClasses.Select(x => x.Name).ToList();
        }

        public bool SetClass(string className)
        {
            if (ReferenceDungeon?.ConfiguredClasses.Find(x =>
                string.Equals(x.Name, className, StringComparison.CurrentCultureIgnoreCase)) == null) return false;
                
            AvatarClass = ReferenceDungeon.ConfiguredClasses.Find(x => string.Equals(x.Name, className, StringComparison.CurrentCultureIgnoreCase));

            return true;

        }

        public (int, IAvatar) BuildAvatar()
        {
            return (ReferenceDungeon.DungeonId, new Avatar(AvatarName, AvatarRace, AvatarClass));
        }


    }
}
