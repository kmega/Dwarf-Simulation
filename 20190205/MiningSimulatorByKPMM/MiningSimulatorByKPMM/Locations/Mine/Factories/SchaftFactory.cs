using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;

namespace MiningSimulatorByKPMM.Locations.Mine.Factories
{
    public static class SchaftFactory
    {
        public static List<MiningSchaft> CreateTwoSchafts()
        {
            return new List<MiningSchaft> { new MiningSchaft(), new MiningSchaft() };
        }
    }
}
