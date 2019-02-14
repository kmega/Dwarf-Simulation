using MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;

namespace MiningSimulatorByKPMM.Locations.Mine.Factories
{
    public static class OreFactory
    {
        public static Ore CreateSingleRandomMiningOutput()
        {
            return new OreRandomizer().GetRandomMineral();
        }
    }
}
