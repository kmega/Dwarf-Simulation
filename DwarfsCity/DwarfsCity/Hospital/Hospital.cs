using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using DwarfsCity.Tools;
using System;
using System.Collections.Generic;
using Type = DwarfsCity.DwarfContener.Type;

namespace DwarfsCity
{
    public class Hospital
    {

        public void GiveBirthToDwarf(List<Dwarf> dwarfs)
        {
            dwarfs.Add(DwarfFactory.CreateARandomDwarf_RandomAttribute());      
        }

        public void InitialNumberOfDwarfs(List<Dwarf> dwarfs,int initalNumberOfDwarfs = 0)
        {
            dwarfs = DwarfFactory.CreateMultipleRandomDwarfs_RandomAttributes(initalNumberOfDwarfs);
        }

    }
}