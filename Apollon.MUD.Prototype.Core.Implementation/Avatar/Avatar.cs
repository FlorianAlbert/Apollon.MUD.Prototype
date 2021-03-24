using System;
using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using System.Collections.Generic;

namespace Apollon.MUD.Prototype.Core.Implementation.Avatar
{
    public class Avatar : IAvatar
    { 
        string IAvatar.Name => throw new NotImplementedException();
        string IAvatar.Discription => throw new NotImplementedException();
        List<IItem> IAvatar.Inventory => throw new NotImplementedException();
        IWearable IAvatar.HeadArmor => throw new NotImplementedException();
        IWearable IAvatar.BodyArmor => throw new NotImplementedException();
        IWearable IAvatar.LegArmor => throw new NotImplementedException();
        IUseable IAvatar.Weapon => throw new NotImplementedException();

        public event ChatHandler Chat;

        public bool AddItemToInventar(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool ConsumeItem(IConsumable consumable)
        {
            throw new NotImplementedException();
        }

        public bool PullOut(IUseable useable)
        {
            throw new NotImplementedException();
        }

        public bool PutIn(IUseable useable)
        {
            throw new NotImplementedException();
        }

        public bool RemoveArmor(IWearable wearable)
        {
            throw new NotImplementedException();
        }

        public void SendPrivateMessage(string message)
        {
            Chat?.Invoke(message);
        }

        public bool ThrowAway(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool UseItem(IUseable useable)
        {
            throw new NotImplementedException();
        }

        public bool WearArmor(IWearable wearable)
        {
            throw new NotImplementedException();
        }
    }

    public delegate void ChatHandler(string message);
}
