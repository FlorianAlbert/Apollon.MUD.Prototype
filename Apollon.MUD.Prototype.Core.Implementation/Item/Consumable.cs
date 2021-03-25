using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System;

namespace Apollon.MUD.Prototype.Core.Implementation.Item
{
    class Consumable : IConsumable
    {
        public Consumable(bool consumableEffect, string consumableName, string consumableDescription)
        {
            GoodEffect = consumableEffect;
            Name = consumableName;
            Description = consumableDescription;
        }

        public bool GoodEffect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get; }

        public string Description { get; }

        public bool Consume(IAvatar avatar)
        {
            throw new NotImplementedException();
        }
    }
}
