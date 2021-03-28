using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Implementation.Item
{
    public class Inspectable : IInspectable
    {
        public Inspectable(string inspectableName, string inspectableDescription)
        {
            Name = inspectableName;
            Description = inspectableDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
