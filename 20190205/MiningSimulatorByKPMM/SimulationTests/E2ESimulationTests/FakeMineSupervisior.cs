using System;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;

namespace SimulationTests.E2ESimulationTests
{
    internal static class FakeMineSupervisior
    {
        internal static MineSupervisor CreateFakeMineSupervisior(ISchaftOperator schaftOperator, IOreUnitAmountRandomizer oreUnitAmountRandomizer, IOreRandomizer oreRandomizer)
        {
            return new MineSupervisor(schaftOperator, oreUnitAmountRandomizer, oreRandomizer);
        }
    }
}
