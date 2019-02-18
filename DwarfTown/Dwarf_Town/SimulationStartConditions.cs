using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Locations.Mine;
using System.Collections.Generic;

namespace Dwarf_Town
{
    public class SimulationStartConditions
    {
        public IOutputWriter Presenter;
        public Guild Guild;
        public Mine Mine;
        public Canteen Canteen;
        public Shop Shop;
        public Hospital Hospital;
        public List<Dwarf> Dwarves;
        public int DwarvesBornFirstDay;
        public int MaxDay;
    }
}