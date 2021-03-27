using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System;

namespace Apollon.MUD.Prototype.Core.Implementation.Item
{
    public class Consumable : IConsumable
    {
        public Consumable(string consumableName, string consumableDescription, string consumableEffect, short weight)
        {
            Effect = consumableEffect;
            Name = consumableName;
            Weight = weight;
            Description = consumableDescription;
        }

        public string Effect { get; set; }

        public string Name { get; }

        public string Description { get; }

        public short Weight { get; set; }

        public bool Consume(IAvatar avatar)
        {
            avatar.SendPrivateMessage("Du konsumierst den Inhalt aus " + Name + ".\n"+ Effect);
            return true;
        }
    }
}
