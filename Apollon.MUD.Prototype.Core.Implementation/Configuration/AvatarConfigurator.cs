using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration
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
                if (!ReferenceDungeon.AllAvatars.Exists(x => x.Name == name))
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
                //send error to client
            }
        }

        public void SetRace(string raceName)
        {
            if (ReferenceDungeon != null)
            {
                if (ReferenceDungeon.ConfiguredRaces.Exists(x => x.Name == raceName))
                {
                    AvatarRace = ReferenceDungeon.ConfiguredRaces.Find(x => x.Name == raceName);
                }
                else
                {
                    //send error to client
                }
            }
            else
            {
                //send error to client
            }
        }

        public void SetClass(string className)
        {
            if (ReferenceDungeon != null)
            {
                if (ReferenceDungeon.ConfiguredClasses.Find(x => x.Name == className) != null)
                {
                    AvatarClass = ReferenceDungeon.ConfiguredClasses.Find(x => x.Name == className);
                }
                else
                {
                    //send error to client
                }
            }
            else
            {
                //send error to client
            }
        }

        public IAvatar BuildAvatar()
        {
            return new Avatar.Avatar(AvatarName, AvatarRace, AvatarClass);
        }


    }
}
