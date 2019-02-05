using MiningSimulatorByKPMM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Guild
{
    public class ValueOfMithril : IRandomGenerator
    {
        public int GenerateSignleRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(15, 25);
        }
    }
}
