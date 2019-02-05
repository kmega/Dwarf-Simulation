using System;
namespace DwarfMineSimulator.Simulation
{
    public class CorealateSimulation : ISimulationBuilder
    {
        Simulation _simulation = new Simulation();

        public void SetSimulationEndConditions()
        {
            //int maxDays = 30;
            // isDwarftCount <= 0
            // 200 rations on start

        }

        public void SetDwarfs()
        {
            // 10 dwarft on first day
            // dwarf has not money when born
        }

        public Simulation GetSimulation()
        {
            return _simulation;
        }
    }
}
