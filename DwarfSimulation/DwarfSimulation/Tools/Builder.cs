using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Builder
    {
        List<Dwarf> listOfDwarves = new List<Dwarf>();
        Randomizer randomizer = new Randomizer();

        internal List<Dwarf> CreateDwarves(int dwarfsNumber)
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < dwarfsNumber; i++)
            {
                dwarves.Add(CreateDwarf(randomizer.ReturnDwarfType()));
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
                        DigAction = new DefaultDigStrategy(),
                        BuyAction = new FatherBuyStrategy()
                    };
                    break;
                case DwarfType.Single:
                    dwarf = new Dwarf()
                    {
                        DigAction = new DefaultDigStrategy(),
                        BuyAction = new SingleBuyStrategy()
                    };
                    break;
                case DwarfType.Lazy:
                    dwarf = new Dwarf()
                    {
                        DigAction = new LazyDigStrategy(),
                        BuyAction = new LazyBuyStrategy()
                    };
                    break;
                case DwarfType.Suicider:
                    dwarf = new Dwarf()
                    {
                        DigAction = new SuiciderDigStrategy(),
                    };
                    break;
                default:
                    dwarf = new Dwarf();
                    break;
            }
            return dwarf;
        }
    }
}
