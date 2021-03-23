using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.Avatar
{
    //TODO Generalisierung von NPC wäre möglich ?!
    public interface IAvatar
    {
        //protected int Health { get ; set; }
        //protected int Damage { get; set; }
        //protected int Protection { get; set; }
        //protected bool Alive { get; set; }
        protected List<IItem> Inventory { get; set; }
        protected IWearable HeadArmor { get; set; }
        protected IWearable BodyArmor { get; set; }
        protected IWearable LegArmor { get; set; }
        protected IUseable Weapon { get; set; }

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
