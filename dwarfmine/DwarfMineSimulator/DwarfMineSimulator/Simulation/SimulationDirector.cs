using System;
namespace DwarfMineSimulator.Simulation
{
    public class SimulationDirector
    {
        private readonly ISimulationBuilder simulationBuilder;

        public SimulationDirector(ISimulationBuilder builder)
        {
            simulationBuilder = builder;
        }

        public void ConfigureSimulation(ISimulationBuilder simulationBuilder)
        {
            simulationBuilder.SetDwarfs();
            simulationBuilder.SetMaterials();
        }

        public Simulation GetSimulation()
        {
            return simulationBuilder.GetSimulation();
        }
    }
}
