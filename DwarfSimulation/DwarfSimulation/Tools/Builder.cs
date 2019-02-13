using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Builder
    {
        List<Dwarf> listOfDwarves = new List<Dwarf>();

        Randomizer randomizer = new Randomizer();


        internal List<Dwarf> CreateDwarves(int dwarfsNumber)
        {
            for (int i = 0; i < dwarfsNumber; i++)
            {

            }
            return null;
        }

        internal Dwarf CreateDwarf(DwarfType type)
        {
           // DwarfType type = randomizer.ReturnDwarfType();

            Dwarf dwarf;

            switch (type)
            {
                case DwarfType.Father:
                    dwarf = new Dwarf() { };
                    break;
                case DwarfType.Single:
                    dwarf = new Dwarf() { BuyAction = new SingleBuyStrategy() };
                    break;
                case DwarfType.Lazy:
                    dwarf = new Dwarf() { };
                    break;
                case DwarfType.Suicider:
                    dwarf = new Dwarf() { };
                    break;
                default:
                    dwarf = new Dwarf();
                    break;
            }
            return dwarf;
        }
    }
}
