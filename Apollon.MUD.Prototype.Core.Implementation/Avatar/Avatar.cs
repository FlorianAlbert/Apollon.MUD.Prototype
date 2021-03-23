using Apollon.MUD.Prototype.Core.Interfaces.Avatar;
using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Implementation.Avatar
{
    public class Avatar : IAvatar
    {
        List<IItem> IAvatar.Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IUseable IAvatar.Weapon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IWearable IAvatar.HeadArmor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IWearable IAvatar.BodyArmor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IWearable IAvatar.LegArmor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        bool IAvatar.AddItemToInventar(IItem item)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.ConsumeItem(IConsumable consumable)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.PullOut(IUseable useable)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.PutIn(IUseable useable)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.RemoveArmor(IWearable wearable)
        {
            throw new NotImplementedException();
        }

        void IAvatar.SendPrivateMessage(string message)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.ThrowAway(IItem item)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.UseItem(IUseable useable)
        {
            throw new NotImplementedException();
        }

        bool IAvatar.WearArmor(IWearable wearable)
        {
            throw new NotImplementedException();
        }
    }

    public delegate void ChatHandler(string message);
}
