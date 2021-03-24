using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.Avatar
{
    //TODO Generalisierung von NPC wäre möglich ?!
    public interface IAvatar
    {
        //int Health { get ; set; }
        //int Damage { get; set; }
        //int Protection { get; set; }
        //bool Alive { get; set; }
        List<IItem> Inventory { get; set; }
        IWearable HeadArmor { get; set; }
        IWearable BodyArmor { get; set; }
        IWearable LegArmor { get; set; }
        IUseable Weapon { get; set; }

        void SendPrivateMessage(string message);
        bool ConsumeItem(IConsumable consumable);
        bool AddItemToInventar(IItem item);
        bool UseItem(IUseable useable);
        bool PullOut(IUseable useable);
        bool PutIn(IUseable useable);
        bool WearArmor(IWearable wearable);
        bool RemoveArmor(IWearable wearable);
        bool ThrowAway(IItem item);
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }
}
