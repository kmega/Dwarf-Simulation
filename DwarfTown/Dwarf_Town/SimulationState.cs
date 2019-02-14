using System.Collections.Generic;

namespace Dwarf_Town
{
    public class SimulationState
    {
        public SimulationState()
        {
            Dwarves = new List<Dwarf>();
        }

        public List<Dwarf> Dwarves { get; set; }
    }
}