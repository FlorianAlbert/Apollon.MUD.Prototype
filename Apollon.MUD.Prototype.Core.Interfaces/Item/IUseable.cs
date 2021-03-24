using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.Item
{
    public interface IUseable : IItem
    {
        //int DamageBoost { get; set; }
        //int Durability { get; set; }

        bool Use();
    }
}
