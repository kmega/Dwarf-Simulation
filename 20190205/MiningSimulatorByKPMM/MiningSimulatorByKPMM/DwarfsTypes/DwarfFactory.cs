using MiningSimulatorByKPMM.DwarfsTypes.BuyStrategies;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class DwarfFactory
    {
        public static IDwarf Create(E_DwarfType dwarfType)
        {
            switch(dwarfType)
            {
                case E_DwarfType.Dwarf_Father:
                    return new Dwarf(dwarfType,new BuyFoodAction());
                default:
                    return null;
            }
        }
    }
}
