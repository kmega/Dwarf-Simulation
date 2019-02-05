using System;

namespace DwarfMineSimulator.Simulation
{
    public class Simulation
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

        public void ShowReport()
        {
            Console.WriteLine("Lazy Born: {0}", LazyBorn);
            Console.WriteLine("Single Born: {0}", SingleBorn);
            Console.WriteLine("Father Born: {0}", FatherBorn);
            Console.WriteLine("Suicide Born: {0}", SuiciderBorn);
            Console.WriteLine("Total Born: {0}", TotalBorn);
            Console.WriteLine("Mithril Minded: {0}", MithrilMinded);
            Console.WriteLine("Gold Minded: {0}", GoldMinded);
            Console.WriteLine("Silver Minded: {0}", SilverMinded);
            Console.WriteLine("Tainted Gold Minded: {0}", TaintedGoldMinded);
            Console.WriteLine("Death Count: {0}", DeathCount);
            Console.WriteLine("Taxed Money: {0}", TaxedMoney);
            Console.WriteLine("Total Money Earned: {0}", TotalMoneyEarned);
            Console.WriteLine("Food Eaten: {0}", FoodEaten);
            Console.WriteLine("Food Bougth: {0}", FoodBought);
            Console.WriteLine("Alcohol Bougth: {0}", FoodBought);
        }
    }
}