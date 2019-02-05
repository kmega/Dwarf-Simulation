using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Factories
{
    public static class DwarfFactory
    {
        public static Dwarf Create(E_DwarfType dwarfType)
        {
            switch(dwarfType)
            {
                case E_DwarfType.Dwarf_Father:
                    return new Dwarf_Father().CreateSingleDwarf();
                case E_DwarfType.Dwarf_Single:
                    return new Dwarf_Single().CreateSingleDwarf();
                case E_DwarfType.Dwarf_Sluggard:
                    return new Dwarf_Single().CreateSingleDwarf();
                case E_DwarfType.Dwarf_Suicide:
                    return new Dwarf_Suicide().CreateSingleDwarf();
                default:
                    return null;
            }
        }
    }
}
