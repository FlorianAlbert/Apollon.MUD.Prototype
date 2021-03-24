using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.NPC
{
    public interface INPC
    {
        //int Health { get ; }
        //int Damage { get; }
        //int Protection { get; }
        //bool Alive { get; set; }
        //IWearable HeadArmor { get; }
        //IWearable BodyArmor { get; }
        //IWearable LegArmor { get; }
        //IUseable Weapon { get; }
        string Name { get; }
        string Description { get; }

        string Speak();
        //int DealDamage();
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }
}
