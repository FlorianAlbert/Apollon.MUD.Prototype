using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.Avatar
{
    //TODO Generalisierung von NPC wäre möglich ?!
    public interface IAvatar
    {
        //protected int Health { get ; }
        //protected int Damage { get; }
        //protected int Protection { get; }
        //protected bool Alive { get; }
        public string Name { get; }
        public string Discription { get;  }
        protected List<IItem> Inventory { get; }
        protected IWearable HeadArmor { get; }
        protected IWearable BodyArmor { get; }
        protected IWearable LegArmor { get; }
        protected IUseable Weapon { get; }

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
