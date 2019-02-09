using System;
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
        //public IDwarf BornDwarf(int dwarfId, int range = 0)
        //{
        //    //return new IDwarf(dwarfId, RandomDwarfType(range), true, 0);
        //}

        private DwarfTypes RandomDwarfType(int range)
        {

            if (range <= Enum.GetNames(typeof(DwarfTypes)).Length)
                return (DwarfTypes)new Random().Next(0, range);
            else
                return DwarfTypes.Sluggard;
        }
    }
}
