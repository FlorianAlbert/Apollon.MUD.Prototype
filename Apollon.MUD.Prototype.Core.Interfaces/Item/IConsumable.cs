using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Interfaces.Item
{
    public interface IConsumable : ITakeable
    {
        string Effect { get; set; }

        bool Consume(IAvatar avatar);
    }
}
