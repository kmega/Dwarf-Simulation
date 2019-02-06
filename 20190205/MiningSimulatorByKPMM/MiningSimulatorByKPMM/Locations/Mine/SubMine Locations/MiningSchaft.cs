using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Mine.Enums;

namespace MiningSimulatorByKPMM.Locations.Mine.SubMineLocations
{
    public class MiningSchaft
    {
        List<Dwarf> CurrentlyMiningDwarfs;
        E_MiningSchaftStatus SchaftStatus = E_MiningSchaftStatus.Operational;
        //tutaj dac faktorke do mineralow? czy do gornika?

        public E_MiningSchaftStatus GetSchaftStatus() => SchaftStatus;

        public void AssingWorkers(List<Dwarf> workers) => CurrentlyMiningDwarfs = workers;
    }
}
