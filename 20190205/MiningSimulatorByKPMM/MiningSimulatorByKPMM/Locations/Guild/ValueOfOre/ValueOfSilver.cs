using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class ValueOfSilver : ICreateOreValue
    {
        public decimal GenerateSingleValue()
        {
            Random rand = new Random();
            return rand.Next(5, 15);

        }
    }
}
