using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    public static class FakeTemporaryWorkerFactory
    {
        public static List<TemporaryWorker> CreateOneWorkingTemporaryWorkerNonSuicide()
        {
            return new List<TemporaryWorker> { new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true) };
        }

        public static List<TemporaryWorker> CreateNWorkingTemporaryWorkerNonSuicide(int amount)
        {
            List<TemporaryWorker> temporaryWorkers = new List<TemporaryWorker>();

            for (int i = 0; i < amount; i++)
            {
                temporaryWorkers.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true));
            }

            return temporaryWorkers;
        }
    }
}
