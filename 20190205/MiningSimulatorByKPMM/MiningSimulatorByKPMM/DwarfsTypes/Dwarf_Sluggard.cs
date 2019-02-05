using System;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf_Sluggard : IDwarfStrategy
    {
        public Dwarf CreateSingleDwarf()
        {
            return new Dwarf(E_DwarfType.Dwarf_Sluggard, null, null);
        }
    }
}
