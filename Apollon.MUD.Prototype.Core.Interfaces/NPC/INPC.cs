using System;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.NPC
{
    public interface INPC : IInspectable
    {
        //int HealthMax { get ; }
        //int Damage { get; }
        //int Protection { get; }
        //bool Alive { get; set; }
        //IWearable HeadArmor { get; }
        //IWearable BodyArmor { get; }
        //IWearable LegArmor { get; }
        //IUseable Weapon { get; }

        string Speak();
        //int DealDamage();
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }
}
