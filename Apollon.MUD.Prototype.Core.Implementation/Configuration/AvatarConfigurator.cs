using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;

namespace Apollon.MUD.Prototype.Core.Implementation.Configuration
{
    public class AvatarConfigurator
    {
        private IDungeon ReferenceDungeon { get; set; }

        public void SetDungeon(IDungeon dungeon)
        {
            ReferenceDungeon = dungeon;
        }

        public void SetRace(string raceName)
        {
            if (ReferenceDungeon != null)
            {
                if (ReferenceDungeon.ConfiguredRaces.Find(x => x.Name == raceName) != null)
                {

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


    }
}
