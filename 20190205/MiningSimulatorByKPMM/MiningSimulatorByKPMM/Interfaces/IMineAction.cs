using System;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Enums;

namespace MiningSimulatorByKPMM.Interfaces
{
    public interface IMineAction
    {
        void Work(E_MiningSchaftStatus SchaftStatus);
    }
}
