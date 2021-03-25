using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Interface.Item
{
    class Inspectable : IInspectable
    {
        public Inspectable(string inspectableName, string inspectableDescription)
        {
            Name = inspectableName;
            Description = inspectableDescription;
        }

        public string Name { get; }

        public string Description { get; }
    }
}
