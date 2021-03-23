using System;
namespace Apollon.MUD.Prototype.Core.Interfaces.Item
{
    public interface IUseable : IItem
    {
        //protected int DamageBoost { get; set; }
        //protected int Durability { get; set; }

        public bool Use();
    }
}
