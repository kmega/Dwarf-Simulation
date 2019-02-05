using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Mine.Enums;

namespace MiningSimulatorByKPMM.Locations.Mine.SubMineLocations
{
    public class MiningSchaft
    {
        List<Dwarf> CurrentlyMiningDwarfs = new List<Dwarf>();
        E_MiningSchaftStatus SchaftStatus = E_MiningSchaftStatus.Operational;

        public E_MiningSchaftStatus GetSchaftStatus() => SchaftStatus;
    }
}
