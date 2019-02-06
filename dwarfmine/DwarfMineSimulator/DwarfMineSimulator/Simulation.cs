using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    internal static class Simulation
    {
        internal static int LazyBorn { get; set; } = 0;
        internal static int SingleBorn { get; set; } = 0;
        internal static int FatherBorn { get; set; } = 0;
        internal static int SuiciderBorn { get; set; } = 0;
        internal static int TotalBorn { get; set; } = 0;

        internal static List<Shaft> ShaftsNumber = new List<Shaft>();

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
        internal static decimal ShopEarned { get; set; }

        internal static List<Dwarf> DwarfsPopulation = new List<Dwarf>();


        internal static void Simulate()
        {
            PrepareSimulation();
            StartSimulation();
        }

        internal static void PrepareSimulation()
        {
            Hospital hospital = new Hospital();

            for (int i = 0; i < 10; i++)
            {
                hospital.CreateNewDwarf(DwarfsPopulation, true);
            }

            ShaftsNumber.Add(new Shaft());
            ShaftsNumber.Add(new Shaft());
        }

        internal static void StartSimulation()
        {
            for (int daysCount = 0; daysCount < 30; daysCount++)
            {
                DayOfWork();

                if (daysCount == 29)
                {
                    Simulation.DisplayRaport();
                }
               
            }
        }

        internal static void DayOfWork()
        {
            Hospital hospital = new Hospital();
            // F
            hospital.TryBirthDwarf(DwarfsPopulation);
            Mines mines = new Mines();
            DwarfsPopulation = mines.MineInShafts(DwarfsPopulation, ShaftsNumber);

            Graveyard graveyard = new Graveyard();
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);
            DeathCount = graveyard.HowManyDead();

            Guild guild = new Guild();
            // F
            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            DiningRoom diningRoom = new DiningRoom();
            if (diningRoom.CanEat(FoodInDiningRoom, DwarfsPopulation))
            { FoodInDiningRoom = diningRoom.DwarfsEat(FoodInDiningRoom, DwarfsPopulation); }



            Shop shop = new Shop();
            shop.BuyProducts(DwarfsPopulation);
            shop.DisplaySaleValues();
            FoodBought += shop.FoodBought;
            AlcoholBought += shop.AlcoholBought;
            ShopEarned += shop.EarnedMoney;
            // F
        }

        internal static void DisplayRaport()
        {
            Console.WriteLine("### Simulation Raport ### \n");
            Console.WriteLine("### HOSPITAL ###");
            Console.WriteLine($"Fathers born: {Simulation.FatherBorn}");
            Console.WriteLine($"Singles born: {Simulation.SingleBorn}");
            Console.WriteLine($"Lazy born: {Simulation.LazyBorn}");
            Console.WriteLine($"Suiciders born: {Simulation.SuiciderBorn} \n");
            Console.WriteLine($"### Mines ###");
            Console.WriteLine($"Mithrill mined: {Simulation.MithrilMinded}");
            Console.WriteLine($"Gold mined: {Simulation.GoldMinded}");
            Console.WriteLine($"Silver mined: {Simulation.SilverMinded}");
            Console.WriteLine($"Tainted gold mined: {Simulation.TaintedGoldMinded} \n");
            Console.WriteLine("### GRAVEYARD ###");
            Console.WriteLine($"Death count: {Simulation.DeathCount} \n");
            Console.WriteLine("### GUILD ###");
            Console.WriteLine($"Taxed money: {Simulation.TaxedMoney}");
            Console.WriteLine($"Total money earned: {Simulation.TotalMoneyEarned} \n");
            Console.WriteLine($"### DINING ROOM ###");
            Console.WriteLine($"Food eaten: {Simulation.FoodEaten} \n");
            Console.WriteLine("### SHOP ###");
            Console.WriteLine($"Food bought: {Simulation.FoodBought}");
            Console.WriteLine($"Alcohol bought: {Simulation.AlcoholBought}");
            Console.WriteLine($"Shop earned: {Simulation.ShopEarned}");

        }
    }
}