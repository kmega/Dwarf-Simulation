using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Actions
{
    internal class ExplodeActions : IMineAction
    {
        public void Work(E_MiningSchaftStatus SchaftStatus)
        {
            if (SchaftStatus == E_MiningSchaftStatus.Operational)
            {
            }
        }
    }
}