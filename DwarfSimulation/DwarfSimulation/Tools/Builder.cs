using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Builder
    {
        Randomizer _randomizer = new Randomizer();

        internal List<Dwarf> CreateDwarves(int dwarfsNumber)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < dwarfsNumber; i++)
            {
                dwarves.Add(CreateDwarf(_randomizer.ReturnDwarfType()));
            }
            return dwarves;
        }

        internal Dwarf CreateDwarf(DwarfType type)
        {

            Dwarf dwarf;
            switch (type)
            {
                case DwarfType.Father:
                    dwarf = new Dwarf()
                    {
                        DwarfType = DwarfType.Father,
                        DigAction = new DefaultDigStrategy(),
                        BuyAction = new FatherBuyStrategy()
                    };
                    break;
                case DwarfType.Single:
                    dwarf = new Dwarf()
                    {
                        DwarfType = DwarfType.Single,
                        DigAction = new DefaultDigStrategy(),
                        BuyAction = new SingleBuyStrategy()
                    };
                    break;
                case DwarfType.Lazy:
                    dwarf = new Dwarf()
                    {
                        DwarfType = DwarfType.Lazy,
                        DigAction = new LazyDigStrategy(),
                        BuyAction = new LazyBuyStrategy()
                    };
                    break;
                case DwarfType.Suicider:
                    dwarf = new Dwarf()
                    {
                        DwarfType = DwarfType.Suicider,
                        DigAction = new SuiciderDigStrategy()
                    };
                    break;
                default:
                    dwarf = new Dwarf();
                    break;
            }
            return dwarf;
        }

        internal List<Shaft> CreateShafts(int shaftsNumber)
        {
            List<Shaft> shafts = new List<Shaft>();

            for (int i = 0; i < shaftsNumber; i++)
            {
                shafts.Add(new Shaft());
            }
            return shafts;
        }
    }
}
