using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState currentSimulationState;
        public SimulationEngine()
        {
            currentSimulationState = new SimulationState();
        }

        public void Start()
        {
            for(; currentSimulationState.Turn <= 30; currentSimulationState.Turn ++)
            {
                //Hospital 
            }
        }
    }
}
