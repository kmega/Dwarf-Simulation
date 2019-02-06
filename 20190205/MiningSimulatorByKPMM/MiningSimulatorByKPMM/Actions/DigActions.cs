using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Actions
{
    public class DigActions : IMineAction
    {
        public void Work(E_MiningSchaftStatus SchaftStatus)
        {
            if (SchaftStatus == E_MiningSchaftStatus.Operational)
            {
                throw new NotImplementedException();
            }
        }
    }
}