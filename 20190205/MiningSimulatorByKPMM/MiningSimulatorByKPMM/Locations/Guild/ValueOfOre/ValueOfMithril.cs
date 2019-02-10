using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class ValueOfMithril : ICreateOreValue
    {
        public decimal GenerateSingleValue()
        {
            Random rand = new Random();
            return rand.Next(15, 25);
        }
    }
}
