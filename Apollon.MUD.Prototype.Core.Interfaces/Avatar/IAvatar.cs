using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.Avatar
{
    //TODO Generalisierung von NPC wäre möglich ?!
    public interface IAvatar
    {
        //int Health { get ; }
        //int Damage { get; }
        //int Protection { get; }
        //bool Alive { get; }
        string Name { get; }
        string Description { get; }
        List<IItem> Inventory { get; }
        IWearable HeadArmor { get; }
        IWearable BodyArmor { get; }
        IWearable LegArmor { get; }
        IUseable Weapon { get; }

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
