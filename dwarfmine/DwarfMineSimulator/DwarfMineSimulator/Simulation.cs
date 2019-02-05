namespace DwarfMineSimulator
{
    internal class Simulation
    {
        int LazyBorn { get; set; }
        int SingleBorn { get; set; }
        int FatherBorn { get; set; }
        int SuiciderBorn { get; set; }
        int TotalBorn { get; set; }

        int MithrilMinded { get; set; }
        int GoldMinded { get; set; }
        int SilverMinded { get; set; }
        int TaintedGoldMinded { get; set; }

        int DeathCount { get; set; }

        decimal TaxedMoney { get; set; }
        decimal TotalMoneyEarned { get; set; }

        int FoodEaten { get; set; }

        int FoodBought { get; set; }
        int AlcoholBought { get; set; }


        public Simulation()
        {
           
        }
    }
}