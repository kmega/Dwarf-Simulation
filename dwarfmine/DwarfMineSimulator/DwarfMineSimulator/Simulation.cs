using System;
using System.Collections.Generic;
using System.Linq;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;
using DwarfMineSimulator.Building.Mine;
using DwarfMineSimulator.Building.Guild;
using DwarfMineSimulator.Building.Restaurant;

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

        int RationsLeft { get; set; }
        int FoodEaten { get; set; }

        int FoodBought { get; set; }
        int AlcoholBought { get; set; }


        public Simulation()
        {
            DayCount = 1;
            DaysToEnd = 30;

            LazyBorn = 0;
            SingleBorn = 0;
            FatherBorn = 0;
            SuiciderBorn = 0;
            TotalBorn = 0;

            MithrilMinded = 0;
            GoldMinded = 0;
            SilverMinded = 0;
            TaintedGoldMinded = 0;

            DeathCount = 0;

            TaxedMoney = 0;
            TotalMoneyEarned = 0;

            RationsLeft = 200;
            FoodEaten = 0;

            FoodBought = 0;
            AlcoholBought = 0;
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
            if (RationsLeft < 1)
                return false;

            return true;
        }

        public void Execute()
        {
            if (DayCount == 1)
            {
                int tenDwarfs = 0;
                while(tenDwarfs < 10)
                {
                    Dwarfs.Add(new DwarfFactory().BornDwarf(Dwarfs.Count + 1,3)); //without suicider
                    Console.WriteLine("A Dwarf type of {0} was born in the hospital.", Dwarfs[Dwarfs.Count - 1].GetDwarfType());

                    DwarfBornCounter();

                    tenDwarfs++;
                }
            }

            Guild Guild = new Guild(Dwarfs);
            Restaurant Restaurant = new Restaurant(Dwarfs);

            while (EndConditions())
            {
                Console.WriteLine();
                Console.WriteLine("Day {0} begins...", DayCount);

                // Hospital
                if (IsChance())
                {
                    Dwarfs.Add(new DwarfFactory().BornDwarf(Dwarfs.Count + 1,4));
                    DwarfBornCounter();
                    Console.WriteLine("A Dwarf type of {0} was born in the hospital.", Dwarfs[Dwarfs.Count - 1].GetDwarfType());
                }

                // Mine
                Mine mine = new Mine(Dwarfs);
                mine.DwarfOnShift(Dwarfs);
                foreach (var dwarf in Dwarfs)
                {
                    MineralsDugCounter(dwarf.MinedMineralsReport());
                }

                // Guild
                TotalMoneyEarned += Guild.Payday();

                // DiningRoom
                Restaurant.FeedDwarfs();
                RationsLeft = Restaurant.RationsLeft();

                // Shop



                Console.WriteLine();
                Console.WriteLine("The end of day {0}", DayCount);
                DayPassed();
            }

            DeathCount = Dwarfs.Count(x => x.IsAlive() == false);
            TaxedMoney = Guild.TotalTaxedMoney();
            FoodEaten = Restaurant.RationsEated();
            Report();
        }

        private void DayPassed()
        {
            DayCount++;
        }

        private bool IsChance()
        {
            return new Random().Next(0, 2) == 1;
        }

        private void Report()
        {
            Console.WriteLine();
            Console.WriteLine("Lazy Born = {0}", LazyBorn);
            Console.WriteLine("Single Born = {0}", SingleBorn);
            Console.WriteLine("Father Born = {0}", FatherBorn);
            Console.WriteLine("Suicider Born = {0}", SuiciderBorn);
            Console.WriteLine("Total Born = {0}", TotalBorn);
            Console.WriteLine();
            Console.WriteLine("Mithril Minded = {0}", MithrilMinded);
            Console.WriteLine("Gold Minded = {0}", GoldMinded);
            Console.WriteLine("Silver Minded = {0}", SilverMinded);
            Console.WriteLine("Tainted Gold Minded = {0}", TaintedGoldMinded);
            Console.WriteLine();
            Console.WriteLine("Death Count = {0}", DeathCount);
            Console.WriteLine();
            Console.WriteLine("Taxed Money Count = {0}", TaxedMoney);
            Console.WriteLine("Total Money Earned Count = {0}", TotalMoneyEarned);
            Console.WriteLine();
            Console.WriteLine("Food Eated Count = {0}", FoodEaten);
            Console.WriteLine("Rations Left in Restauran Count = {0}", RationsLeft);
        }

        private void DwarfBornCounter()
        {
            switch(Dwarfs[Dwarfs.Count - 1].GetDwarfType())
            {
                case DwarfTypes.Lazy:
                    LazyBorn++;
                    break;
                case DwarfTypes.Single:
                    SingleBorn++;
                    break;
                case DwarfTypes.Father:
                    FatherBorn++;
                    break;
                case DwarfTypes.Suicider:
                    SuiciderBorn++;
                    break;
            }

            TotalBorn++;
        }

        private void MineralsDugCounter(Dictionary<Minerals, int> mineralsToCount)
        {
            foreach (var mineral in mineralsToCount)
            {
                if(mineral.Key.Equals(Minerals.Mithril))
                {
                    MithrilMinded += mineral.Value;
                }

                if (mineral.Key.Equals(Minerals.Gold))
                {
                    GoldMinded += mineral.Value;
                }

                if (mineral.Key.Equals(Minerals.Silver))
                {
                    SilverMinded += mineral.Value;
                }

                if (mineral.Key.Equals(Minerals.TaintedGold))
                {
                    TaintedGoldMinded += mineral.Value;
                }
            }
        }
    }
}