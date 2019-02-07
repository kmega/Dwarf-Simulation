using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace MiningSimulatorByKPMM.Locations.Mine.Interfaces
{
    public interface ISchaftOperator
    {
        E_MiningSchaftStatus DoWork(List<TemporaryWorker> workers, E_MiningSchaftStatus SchaftStatus, IOreRandomizer oreRandomizer, IOreUnitAmountRandomizer oreUnitAmountRandomizer);
    }
}
