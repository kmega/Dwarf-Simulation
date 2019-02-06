using System;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    internal class IsDwarfBorn1PercentStrategy : IBirthChanceRandomizer
    {
        public bool IsDwarfBorn()
        {
            var random = new Random().Next(0,99);
            if (random == 0)
            {
                return true;
            }
            else return false;
        }
    }
}