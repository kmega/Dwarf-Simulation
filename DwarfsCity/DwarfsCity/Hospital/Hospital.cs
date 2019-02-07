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
            var listOfDwarfs = DwarfFactory.CreateMultipleRandomDwarfs_RandomAttributes(initalNumberOfDwarfs);

            foreach (var dwarf in listOfDwarfs)
            {
                dwarfs.Add(dwarf);
            }
        }

    }
}