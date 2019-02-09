using System;
using System.Linq;
using DwarfLife.Enums;
using DwarfLife.Dwarfs;

namespace DwarfLife.Buildings
{
    public class Hospital
    {
        public IDwarf BornDwarf(int dwarfId, DwarfTypes dwarfType)
        {
            switch (dwarfType)
            {
                case DwarfTypes.Father:
                    return new DwarfFather(dwarfId);
                case DwarfTypes.Single:
                    return new DwarfSingle(dwarfId);
                case DwarfTypes.Sluggard:
                    return new DwarfSluggard(dwarfId);
                case DwarfTypes.Saboteur:
                    return new DwarfSaboteur(dwarfId);
                default:
                    return null;
            }
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
