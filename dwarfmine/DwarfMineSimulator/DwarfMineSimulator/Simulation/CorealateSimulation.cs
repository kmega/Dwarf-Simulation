using System;
namespace DwarfMineSimulator.Simulation
{
    public class CorealateSimulation : ISimulationBuilder
    {
        Simulation _simulation = new Simulation();

        public void SetDaysLimit(int maxDays)
        {

        }

        public void SetSimulationEndConditions()
        {

        }

        public void SetDwarfs()
        {

        }

        public void SetMaterials()
        {

        }

        public Simulation GetSimulation()
        {
            return _simulation;
        }
    }
}
