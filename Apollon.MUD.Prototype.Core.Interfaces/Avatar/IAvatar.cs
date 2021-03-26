using System.Collections.Generic;
using System.Threading.Tasks;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interfaces.Avatar
{
    public interface IAvatar : IInspectable
    {
        IRace Race { get; }
        IClass Class { get; }
        int HealthMax { get; }
        int Damage { get; }
        int Protection { get; }

        string ConnectionId { get; }

        event ChatHandler Chat;
        //bool Alive { get; }
        //List<IInspectable> Inventory { get; }
        //IWearable HeadArmor { get; }
        //IWearable BodyArmor { get; }
        //IWearable LegArmor { get; }
        //IUseable Weapon { get; }

        void SendPrivateMessage(string message);
        //bool ConsumeItem(IConsumable consumable);
        bool AddItemToInventory(ITakeable inspectable);
        List<string> GetInventoryContent();
        //bool UseItem(IUseable useable);
        //bool PullOut(IUseable useable);
        //bool PutIn(IUseable useable);
        //bool WearArmor(IWearable wearable);
        //bool RemoveArmor(IWearable wearable);
        ITakeable ThrowAway(string itemName);
        //bool IncreaseHealth(int Amount);
        //bool DecreaseHealth(int Amount);
    }

    public delegate Task ChatHandler(string message, string connectionId);
}
