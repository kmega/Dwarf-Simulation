using MiningSimulatorByKPMM.Interfaces;
using System;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    internal class DwarfBirthChanceGenerator : IRandomGenerator
    {
        public int GenerateSignleRandomNumber()
        {
            return new Random().Next(0, 99);
        }
    }
}