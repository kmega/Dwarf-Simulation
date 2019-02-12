using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine.Interfaces
{
    public interface ISchaftStrategy
    {
        void DoWork(TemporaryWorker worker, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer);
    }
}
