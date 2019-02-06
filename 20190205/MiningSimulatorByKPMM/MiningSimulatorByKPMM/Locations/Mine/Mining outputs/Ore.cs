using System;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;

namespace MiningSimulatorByKPMM.Locations.Mine.Miningoutputs
{
    public class Ore
    {
        public E_Minerals OutputType { get;}

        public Ore(E_Minerals type)
        {
            OutputType = type;
        }


    }
}
