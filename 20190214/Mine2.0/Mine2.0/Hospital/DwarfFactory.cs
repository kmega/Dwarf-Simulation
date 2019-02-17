namespace Mine2._0
{
    public static class DwarfFactory
    {
        public static Dwarf CreateSingleDwarf(E_DwarfType dwarfType)
        {
            switch (dwarfType)
            {
                default:
                case E_DwarfType.Father:
                    return new Dwarf(dwarfType, new NormalWorkingStrategy(), new FoodBuyingStrategy());
                case E_DwarfType.Single:
                    return new Dwarf(dwarfType, new NormalWorkingStrategy(), new AlcoholBuyingStrategy());
                case E_DwarfType.Sabouter:
                    return new Dwarf(dwarfType, new KaboomWorkingStrategy(), null);
                case E_DwarfType.Sluggard:
                    return new Dwarf(dwarfType, new NormalWorkingStrategy(), new FoodBuyingStrategy());
            }
        }
    }
}
