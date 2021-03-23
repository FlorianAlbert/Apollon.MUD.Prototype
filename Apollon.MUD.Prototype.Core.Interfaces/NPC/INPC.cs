using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.NPC
{
    public interface INPC
    {
        //protected int Health { get ; set; }
        //protected int Damage { get; set; }
        //protected int Protection { get; set; }
        //protected bool Alive { get; set; }
        //protected IWearable HeadArmor { get; set; }
        //protected IWearable BodyArmor { get; set; }
        //protected IWearable LegArmor { get; set; }
        //protected IUseable Weapon { get; set; }

        public string Speak();
        //public int DealDamage();
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }
}
