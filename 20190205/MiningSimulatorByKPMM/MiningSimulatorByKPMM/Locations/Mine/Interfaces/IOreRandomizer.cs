using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;

namespace MiningSimulatorByKPMM.Locations.Mine.Interfaces
{
    public interface IOreRandomizer
    {
        Ore GetRandomMineral();
        E_Minerals GetOreType();
    }
}
