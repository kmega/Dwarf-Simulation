using System;
using System.Collections.Generic;
using System.Linq;

namespace DwarfMineSimulator
{
    internal class Simulation
    {
        internal List<Shaft> ShaftsNumber = new List<Shaft>();
        internal List<Dwarf> DwarfsPopulation = new List<Dwarf>();

        internal void Simulate()
        {
            PrepareSimulation();
            StartSimulation();
        }

        internal void PrepareSimulation()
        {
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            hospital.HowManyYouWantCreate(10, DwarfsPopulation);

            ShaftsNumber.Add(new Shaft());
            ShaftsNumber.Add(new Shaft());
        }

        internal void StartSimulation()
        {
            for (int daysCount = 0; daysCount < 30; daysCount++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"#### Day {daysCount + 1} ####\n");
                Console.ResetColor();

                if (DayOfWork()) break;
                Console.ReadKey();
                Console.Clear();
            }

            string raport = Raport.EndGameStats();
            Console.WriteLine(raport);
        }

        internal bool DayOfWork()
        {
            Hospital hospital = new Hospital();
            hospital.TryBirthDwarf(DwarfsPopulation);

            Mines mines = new Mines();
            DwarfsPopulation = mines.MineInShafts(DwarfsPopulation, ShaftsNumber);

            Graveyard graveyard = new Graveyard();
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);

            Raport.DeathCount += graveyard.HowManyDead();
            if (DwarfsPopulation.Count() == 0) return true;

            Guild guild = new Guild();
            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            DiningRoom diningRoom = new DiningRoom();
            if (!(diningRoom.CanEat(Raport.FoodInDiningRoom, DwarfsPopulation))) return true;

            Raport.FoodInDiningRoom = diningRoom.DwarfsEat(Raport.FoodInDiningRoom, DwarfsPopulation); 

            Shop shop = new Shop();
            shop.BuyProducts(DwarfsPopulation);
            shop.DisplaySaleValues();

            Raport.FoodBought += shop.FoodBought;
            Raport.AlcoholBought += shop.AlcoholBought;
            Raport.ShopEarned += shop.EarnedMoney;

            return false;
        }
    }
}