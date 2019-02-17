using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class DwarfFactory
    {
        public static Dwarf CreateDwarf(DwarfType dwarfType)
        {
            switch(dwarfType)
            {
                default:
                case DwarfType.Father:
                    return new Dwarf(dwarfType, new FatherShoppingStrategy(), new StandardWorkingStrategy());
                case DwarfType.Lazy:
                    return new Dwarf(dwarfType, new LazyShoppingStrategy(), new StandardWorkingStrategy());
                case DwarfType.Single:
                    return new Dwarf(dwarfType, new SingleShoppingStrategy(), new StandardWorkingStrategy());
                case DwarfType.Bomber:
                    return new Dwarf(dwarfType, new LazyShoppingStrategy(), new BomberWorkingStrategy());      
            }
        }
    }
}
