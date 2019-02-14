using System.Collections.Generic;

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
    }
}
