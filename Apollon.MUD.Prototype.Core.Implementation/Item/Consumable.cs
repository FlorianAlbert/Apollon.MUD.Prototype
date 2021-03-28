using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System;

namespace Apollon.MUD.Prototype.Core.Implementation.Item
{
    public class Consumable : IConsumable
    {
        public Consumable(bool consumableEffect, string consumableName, string consumableDescription)
        {
            GoodEffect = consumableEffect;
            Name = consumableName;
            Description = consumableDescription;
        }

        public bool GoodEffect { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Consume(IAvatar avatar)
        {
            throw new NotImplementedException();
        }
    }
}
