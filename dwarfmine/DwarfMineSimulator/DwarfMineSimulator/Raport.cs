namespace DwarfMineSimulator
{
    internal static class Raport
    {
        internal static int LazyBorn { get; set; } = 0;
        internal static int SingleBorn { get; set; } = 0;
        internal static int FatherBorn { get; set; } = 0;
        internal static int SuiciderBorn { get; set; } = 0;
        internal static int TotalBorn { get; set; } = 0;

        internal static int MithrilMinded { get; set; } = 0;
        internal static int GoldMinded { get; set; } = 0;
        internal static int SilverMinded { get; set; } = 0;
        internal static int TaintedGoldMinded { get; set; } = 0;

        internal static int DeathCount { get; set; } = 0;

        internal static decimal TaxedMoney { get; set; } = 0.0m;
        internal static decimal TotalMoneyEarned { get; set; } = 0.0m;

        internal static int FoodEaten { get; set; } = 0;
        internal static int FoodInDiningRoom { get; set; } = 200;

        internal static int FoodBought { get; set; } = 0;
        internal static int AlcoholBought { get; set; } = 0;
        internal static decimal ShopEarned { get; set; } = 0.0m;

        internal static string EndGameStats()
        {
            string raport = "#### Simulation Raport ####\n"
                + "\n## HOSPITAL ##  \n\n"
                + "Fathers born: " + FatherBorn + "\n"
                + "Singles born: " + SingleBorn + "\n"
                + "Lazy born: " + LazyBorn + "\n"
                + "Suiciders born: " + SuiciderBorn
                + "\nTotal born: " + TotalBorn + "\n"
                + "\n## MINES ## \n\n"
                + "Mithrill mined: " + MithrilMinded.ToString() + "\n"
                + "Gold mined: " + GoldMinded.ToString() + "\n"
                + "Silver mined: " + SilverMinded + "\n"
                + "Tainted gold mined: " + TaintedGoldMinded + "\n"
                + "\n## GRAVEYARD ## \n\n"
                + "Death count: " + DeathCount + "\n"
                + "\n## GUILD ##\n\n"
                + "Taxed money: " + TaxedMoney + "\n"
                + "Total money earned: " + TotalMoneyEarned + "\n"
                + "\n## DINING ROOM ## \n\n"
                + "Food eaten: " + FoodEaten + "\n"
                + "\n## SHOP ## \n\n"
                + "Food bought: " + FoodBought + "\n"
                + "Alcohol bought: " + AlcoholBought + "\n"
                + "Shop earned: " + ShopEarned +"\n";

            return raport;
        }
    }
}
