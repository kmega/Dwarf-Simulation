using System;
using System.Diagnostics.Contracts;
using DwarfMineSimulator.Enums;

namespace DwarfMineSimulator.Dwarfs
{
    internal class DwarfFactory
    {
        public Dwarf BornDwarf(int range = 0)
        {
            return new Dwarf(RandomDwarfType(range), true, 0);
        }

        private DwarfTypes RandomDwarfType(int range)
        {
            if (range <= Enum.GetNames(typeof(DwarfTypes)).Length)
                return (DwarfTypes)new Random().Next(0, range);
            else
                return DwarfTypes.Lazy;
        }
    }
}