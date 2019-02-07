using System;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;

namespace MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft
{
    public class OreUnitAmountRandomizer : IOreUnitAmountRandomizer
    {
        public int GetAmountOfOreUnintsToRandom()
        {
            return new Random().Next(1, 3);
        }
    }
}
