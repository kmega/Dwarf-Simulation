using System;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf_Single : IDwarfStrategy
    {
        public Dwarf CreateSingleDwarf()
        {
            return new Dwarf(E_DwarfType.Dwarf_Single, null, null);
        }
    }
}
