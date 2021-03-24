using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Interfaces.Item
{
    public interface IConsumable : IItem
    {
        bool GoodEffect { get; set; }

        bool Consume(IAvatar avatar);
    }
}
