using Apollon.MUD.Prototype.Core.Interfaces.Avatar;

namespace Apollon.MUD.Prototype.Core.Implementation.Avatar
{
    public class Avatar : IAvatar
    {
        public event ChatHandler Chat;

        public void SendPrivateMessage(string message)
        {
            Chat?.Invoke(message);
        }
    }

    public delegate void ChatHandler(string message);
}
