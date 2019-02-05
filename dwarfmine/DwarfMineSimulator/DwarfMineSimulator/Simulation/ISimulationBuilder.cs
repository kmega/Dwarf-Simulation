using System;
namespace DwarfMineSimulator.Simulation
{
    public interface ISimulationBuilder
    {
        void SetSimulationEndConditions();
        void SetDwarfs();

        Simulation GetSimulation();
    }
}
