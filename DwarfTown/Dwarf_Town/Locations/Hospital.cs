using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using System;

namespace Dwarf_Town.Locations
{
    internal class Hospital : IChance, IGenerate
    {
        public Dwarf Generate()
        {
            Dwarf dwarf = new Dwarf();

            if (GenerateChance(1, 100) == 1)
            {
                //int chance = GenerateChance(1, 100);

                //if (chance >= 1 && chance <= 33)
                //{
                //    dwarf = new Dwarf() { DwarfType = DwarfType.FATHER };
                //}
                //if (chance > 33 && chance <= 66)
                //{
                //    dwarf = new Dwarf() { DwarfType = DwarfType.IDLER };
                //}
                //if (chance > 66 && chance <= 99)
                //{
                //    dwarf = new Dwarf() { DwarfType = DwarfType.SINGLE };
                //}
                //if (chance == 100)
                //{
                //    dwarf = new Dwarf() { DwarfType = DwarfType.SUICIDE };
                //}
            }
            return dwarf;
        }

        public int GenerateChance(int lowerBound, int upperBound)
        {
            Random random = new Random();
            return random.Next(lowerBound, upperBound);
        }


    }
}