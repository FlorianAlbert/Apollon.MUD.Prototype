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
        public string Name { get; }
        public string Description => Race.Description;

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

        public event ChatHandler Chat;

        public Avatar(string avatarName, IRace avatarRace, IClass avatarClass)
        {
            Name = avatarName;
            Race = avatarRace;
            Class = avatarClass;
        }

        public bool AddItemToInventory(ITakeable inspectable)
        {
            Inventory.Add(inspectable);
            return Inventory.Contains(inspectable);
        }

        public List<string> GetInventoryContent()
        {
            var result = Inventory.Select(x => x.Name).ToList();
            return result;
        }

        public void SendPrivateMessage(string message)
        {
            Chat?.Invoke(message);
        }

        public ITakeable ThrowAway(string itemName)
        {
            var itemToRemove = Inventory.Find(x => x.Name == itemName);
            Inventory.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}
