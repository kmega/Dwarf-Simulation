using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Hospital
{
    public class Hospital
    {
        public void Create(SimulationState simulationState)
        {
            if(simulationState.Turn == 1)
            {
                simulationState.Dwarves.AddRange(CreateInitialDwarves());
            }
            else
            {
                simulationState.Dwarves.AddRange(CreateSingleRandomDwarf());
            }
        }
        private List<IDwarf> CreateInitialDwarves()
        {
            return null;
        }
        private List<IDwarf> CreateSingleRandomDwarf()
        {
            return null;
        }
    }
}
