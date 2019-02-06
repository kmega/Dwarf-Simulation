using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    internal class Simulation
    {
        List<Dwarf> Dwarfs = new List<Dwarf>();

        int DaysToEnd { get; set; }
        int DayCount { get; set; }

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
            DayCount = 1;
            DaysToEnd = 30;
        }

        public void SetDaysToEnd(int days)
        {
            DaysToEnd = days;
        }

        private bool EndConditions()
        {
            if (DaysToEnd < DayCount)
                return false;
            if (Dwarfs.Count == 0)
                return false;
            else
                return true;
        }

        public void Execute()
        {
            while (EndConditions())
            {
                Console.WriteLine("Day {0} begins...", DayCount);
                Console.WriteLine("The end of day {0}", DayCount);
                DayPassed();
            }
        }

        private void DayPassed()
        {
            DayCount++;
        }
    }
}