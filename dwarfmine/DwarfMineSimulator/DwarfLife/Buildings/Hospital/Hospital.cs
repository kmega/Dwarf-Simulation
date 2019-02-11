using System;
using System.Linq;
using System.Collections.Generic;
using DwarfLife.Enums;
using DwarfLife.Dwarfs;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Hospital
{
    public class Hospital
    {
        public List<IDwarf> BornedDwarfs { get; private set; }

        public Hospital()
        {
            BornedDwarfs = new List<IDwarf>();
        }

        public IDwarf BornDwarf(int dwarfId, DwarfTypes dwarfType)
        {
            IDwarf dwarf;
            switch (dwarfType)
            {
                case DwarfTypes.Father:
                    dwarf = new DwarfFather(dwarfId, Places.Hospital);
                    BornedDwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Single:
                    dwarf = new DwarfSingle(dwarfId, Places.Hospital);
                    BornedDwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Sluggard:
                    dwarf = new DwarfSluggard(dwarfId, Places.Hospital);
                    BornedDwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Saboteur:
                    dwarf = new DwarfSaboteur(dwarfId, Places.Hospital);
                    BornedDwarfs.Add(dwarf);
                    return dwarf;
                default:
                    return null;
            }
        }

        public List<IDwarf> BornDwarfes(int howMany)
        {
            List<IDwarf> dwarfes = new List<IDwarf>();
            for(int i = 1; i <= howMany; i++)
                dwarfes.Add(BornRandomTypeDwarf(i));

            return dwarfes;
        }

        public IDwarf BornRandomTypeDwarf(int dwarfId)
        {
            return BornDwarf(dwarfId, RandomDwarfType());
        }

        public DwarfTypes RandomDwarfType()
        {
            var dwarfTypes = (DwarfTypes)15;

            var dwarfTypesArray = Enum.GetValues(typeof(DwarfTypes))
                   .Cast<DwarfTypes>()
                   .Where(dwarfType => (dwarfTypes & dwarfType) == dwarfType)
                   .ToArray();

            var RadnomDwarfType = dwarfTypesArray[new Random().Next(1, dwarfTypesArray.Length)];
            return RadnomDwarfType;
        }
    }
}
