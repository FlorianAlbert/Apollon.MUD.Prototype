using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Interfaces.Item
{
    public interface IConsumable : IItem
    {
        protected bool GoodEffect { get; set; }

        public bool Consume(IAvatar avatar);
    }
}
