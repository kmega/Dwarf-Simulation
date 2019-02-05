using MiningSimulatorByKPMM.Interfaces;
using System;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    internal class DwarfTypeGenerator : IRandomGenerator
    {
        public int GenerateSignleRandomNumber()
        {
            return new Random().Next(1, 100);
        }
    }
}