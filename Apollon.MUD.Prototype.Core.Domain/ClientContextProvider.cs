using System.Collections.Generic;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class ClientContextProvider
    {
        public Dictionary<string, ClientContext> Clients { get; }

        public ClientContextProvider()
        {
            Clients = new Dictionary<string, ClientContext>();
        }
    }
}