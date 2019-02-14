using DwarfLifeSimulation.Dwarves.Interfaces;
using System.Collections.Generic;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationState
    {
        public int turn { get; set; }
        public List<IDwarf> dwarves { get; set; }

        public SimulationState()
        {
            turn = 1;
            dwarves = new List<IDwarf>();
        }
    }
}
