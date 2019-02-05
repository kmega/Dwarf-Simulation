using System;
namespace DwarfMineSimulator.Simulation
{
    public interface ISimulationBuilder
    {
        void SetDaysLimit(int maxDays);
        void SetSimulationEndConditions();
        void SetDwarfs();
        void SetMaterials();

        Simulation GetSimulation();
    }
}
