using Apollon.MUD.Prototype.Core.Interfaces.Item;

namespace Apollon.MUD.Prototype.Core.Implementation.Item
{
    public class Takeable : ITakeable
    {
        public Takeable(string takeableName, string takeableDescription, short takeableWeight)
        {
            Name = takeableName;
            Description = takeableDescription;
            Weight = takeableWeight;
        }

        public string Name { get; }

        public string Description { get; set; }

        public short Weight { get; }
    }
}
