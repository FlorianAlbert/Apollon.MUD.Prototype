using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;
using System.Linq;
using Apollon.MUD.Prototype.Core.Interfaces.Configuration.AvatarConfigs;

namespace Apollon.MUD.Prototype.Core.Interface.Avatar
{
    public class Avatar : IAvatar
    { 
        public string Name { get; set; }
        //public string Description => Race.Description;

        public string Description
        {
            get { return Race.Description ; }
            set { Race.Description = value; }
        }


        private List<ITakeable> _Inventory;

        private List<ITakeable> Inventory
        {
            get { return _Inventory ??= new List<ITakeable>(); }
        }

        public IRace Race { get; }

        public IClass Class { get; }

        public int HealthMax => Race.DefaultHealthMax + Class.DefaultHealthMax;

        public int Damage => Race.DefaultDamage + Class.DefaultDamage;

        public int Protection => Race.DefaultProtection + Class.DefaultProtection;

        public string ConnectionId { get; }

        public event ChatHandler Chat;

        public Avatar(string avatarName, IRace avatarRace, IClass avatarClass, string connectionId)
        {
            Name = avatarName;
            Race = avatarRace;
            Class = avatarClass;
            ConnectionId = connectionId;
        }

        public bool AddItemToInventory(ITakeable inspectable)
        {
            Inventory.Add(inspectable);
            SendPrivateMessage("Du nimmst " + inspectable.Name +" auf.");
            return Inventory.Contains(inspectable);
        }

        public void GetInventoryContent()
        {
            var items = Inventory.Select(x => x.Name).ToList();
            var content = "Inventar:";
            foreach (var item in items)
            {
                content += "\n"+ item;
            }
            SendPrivateMessage(content);
        }

        public void SendPrivateMessage(string message)
        {
            Chat?.Invoke(message, ConnectionId);
        }

        public ITakeable ThrowAway(string itemName)
        {
            var itemToRemove = Inventory.Find(x => string.Equals(itemName, x.Name, StringComparison.CurrentCultureIgnoreCase));
            if (Inventory.Remove(itemToRemove))
            {
                SendPrivateMessage("Du wirfst " + itemName + " auf den Boden.");
            }
            else
            {
                SendPrivateMessage("Du hast nichts in deinem Inventar, dass " + itemName + "heißt.");
            }
            return itemToRemove;
        }

        public void ConsumeItem(string consumable)
        {
            var item = Inventory.Find(x => string.Equals(consumable, x.Name, StringComparison.CurrentCultureIgnoreCase));
            if(item is IConsumable consumableItem)
            {
                SendPrivateMessage("Du konsumierst " + consumable + ".\n" + consumableItem.Effect);
                ThrowAway(consumable);
            }
            else
            {
                SendPrivateMessage("Es gibt nichts mit dem Namen " + consumable + " in deinem Inventar, was du zu dir nehmen kannst!");
            }
        }
    }
}
