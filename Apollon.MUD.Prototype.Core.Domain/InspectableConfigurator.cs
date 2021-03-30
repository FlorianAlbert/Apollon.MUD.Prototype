using System;
using System.Collections.Generic;
using Apollon.MUD.Prototype.Core.Interfaces.Dungeon;
using Apollon.MUD.Prototype.Core.Interfaces.Item;
using Apollon.MUD.Prototype.Core.Implementation.Item;

namespace Apollon.MUD.Prototype.Core.Domain
{
    public class InspectableConfigurator
    {
        //TODO
        private IDungeon ReferenceDungeon { get; set; }
        List<IInspectable> ConfiguredInspectables { get; }

        public InspectableConfigurator SetDungeon(IDungeon dungeon)
        {
            if (dungeon == null) { throw new ArgumentNullException(); }
            ReferenceDungeon = dungeon;
            ConfiguredInspectables.AddRange(ReferenceDungeon.ConfiguredInspectables);
            return this;
        }

        public void SaveChanges()
        {
            ReferenceDungeon.ConfiguredInspectables.Clear();
            ReferenceDungeon.ConfiguredInspectables.AddRange(ConfiguredInspectables);
        }

        public bool AddInspectable(string name, string description)
        {
            if (ConfiguredInspectables.Exists(x => string.Equals(name, x.Name, StringComparison.CurrentCultureIgnoreCase))) { return false; }
            ConfiguredInspectables.Add(new Inspectable(name, description));
            return true;
        }

        public bool AddTakable(string name, string description, short weight)
        {
            if (ConfiguredInspectables.Exists(x => string.Equals(name, x.Name, StringComparison.CurrentCultureIgnoreCase))) { return false; }
            ConfiguredInspectables.Add(new Takeable(name, description, weight));
            return true;
        }

        public bool AddConsumable(string name, string description, string effect, short weight)
        {
            if (ConfiguredInspectables.Exists(x => string.Equals(name, x.Name, StringComparison.CurrentCultureIgnoreCase))) { return false; }
            ConfiguredInspectables.Add(new Consumable(name, description, effect, weight));
            return true;
        }
    }
}
