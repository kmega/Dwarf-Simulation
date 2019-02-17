using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Locations.Mine;
using System.Collections.Generic;

namespace Dwarf_Town
{
    public class SimulationStartConditions
    {
        //public int DwarvesAtStart { get; private set; }
        //public int Rounds { get; private set; }
        //public int FoodRationsAtStart { get; private set; }

        //public SimulationStartConditions(int dwarvesAtStart, int rounds, int foodRationsAtStart)
        //{
        //    DwarvesAtStart = dwarvesAtStart;
        //    Rounds = rounds;
        //    FoodRationsAtStart = foodRationsAtStart;
        //}


        public Guild Guild;
        public Mine Mine;
        public Canteen Canteen;
        public Shop Shop;
        public Hospital Hospital;
        public IOutputWriter Presenter;
        public int MaxDay;
        public List<Dwarf> Dwarves;
        public int DwarvesBornFirstDay;
    }
}