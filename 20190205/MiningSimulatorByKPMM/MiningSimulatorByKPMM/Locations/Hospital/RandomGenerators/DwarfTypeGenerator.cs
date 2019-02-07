using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;

namespace MiningSimulatorByKPMM.Locations.Hospital.RandomGenerators
{
    internal class DwarfTypeGenerator : IDwarfTypeRandomizer
    {
        public E_DwarfType GenerateType()
        {
            var random = new Random().Next(0, 99);
            if(random == 0)
            {
                return E_DwarfType.Dwarf_Suicide;
            }
            else if(random>0 && random <= 33)
            {
                return E_DwarfType.Dwarf_Father;
            }
            else if(random>33 && random<=66)
            {
                return E_DwarfType.Dwarf_Single;
            }
            else
            {
                return E_DwarfType.Dwarf_Sluggard;
            }
        }
    }
}
