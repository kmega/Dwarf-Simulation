
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class ValueOfDirtGold : ICreateOreValue
    {
        public decimal GenerateSingleValue()
        {
            return 2;
        }
    }
}
