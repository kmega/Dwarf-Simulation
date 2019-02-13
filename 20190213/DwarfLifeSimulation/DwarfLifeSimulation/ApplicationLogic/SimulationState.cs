using DwarfLifeSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationState
    {
        public int Turn { get; set; }
        public List<IDwarf> Dwarves { get; set; }
    }
}
