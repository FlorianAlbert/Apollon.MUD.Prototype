using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.NPC
{
    public interface INPC
    {
        //protected int Health { get ; }
        //protected int Damage { get; }
        //protected int Protection { get; }
        //protected bool Alive { get; set; }
        //protected IWearable HeadArmor { get; }
        //protected IWearable BodyArmor { get; }
        //protected IWearable LegArmor { get; }
        //protected IUseable Weapon { get; }
        public string Name { get; }
        public string Discription { get; }

        public string Speak();
        //public int DealDamage();
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }
}
