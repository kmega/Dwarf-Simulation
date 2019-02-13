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
        public int BornedDwarfs { get; private set; }
        public List<IDwarf> Dwarfs { get; private set; }

        public Hospital()
        {
            BornedDwarfs = 0;
            Dwarfs = new List<IDwarf>();
        }

        public IDwarf BornDwarf(int dwarfId, DwarfTypes dwarfType)
        {
            IDwarf dwarf;
            switch (dwarfType)
            {
                case DwarfTypes.Father:
                    dwarf = new DwarfFather(dwarfId, Places.Hospital);
                    BornedDwarfs++;
                    Dwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Single:
                    dwarf = new DwarfSingle(dwarfId, Places.Hospital);
                    BornedDwarfs++;
                    Dwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Sluggard:
                    dwarf = new DwarfSluggard(dwarfId, Places.Hospital);
                    BornedDwarfs++;
                    Dwarfs.Add(dwarf);
                    return dwarf;
                case DwarfTypes.Saboteur:
                    dwarf = new DwarfSaboteur(dwarfId, Places.Hospital);
                    BornedDwarfs++;
                    Dwarfs.Add(dwarf);
                    return dwarf;
                default:
                    return null;
            }
        }

        public List<IDwarf> BornDwarfes(int howMany, DwarfTypes dwarfTypes = (DwarfTypes)15)
        {
            List<IDwarf> dwarfes = new List<IDwarf>();
            for(int i = 1; i <= howMany; i++)
                dwarfes.Add(BornRandomTypeDwarf(i, dwarfTypes));

            return dwarfes;
        }

        public IDwarf BornRandomTypeDwarf(int dwarfId, DwarfTypes dwarfTypes = (DwarfTypes)15)
        {
            return BornDwarf(dwarfId, RandomDwarfType(dwarfTypes));
        }

        public DwarfTypes RandomDwarfType(DwarfTypes dwarfTypes = (DwarfTypes)15)
        {
            var dwarfTypesArray = Enum.GetValues(typeof(DwarfTypes))
                   .Cast<DwarfTypes>()
                   .Where(dwarfType => (dwarfTypes & dwarfType) == dwarfType)
                   .ToArray();

            var RadnomDwarfType = dwarfTypesArray[new Random().Next(1, dwarfTypesArray.Length)];
            return RadnomDwarfType;
        }
    }
}
