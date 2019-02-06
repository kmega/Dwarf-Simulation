using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public  class ValueOfGold : ICreateOreValue
    {
        public int GenerateSingleValue()
        {
            Random rand = new Random();
            return rand.Next(10, 20);
        }
    }
}
