﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace DwarfMineSimulator
{
    internal static class Simulation
    {
        internal static List<Shaft> ShaftsNumber = new List<Shaft>();
        internal static List<Dwarf> DwarfsPopulation = new List<Dwarf>();


        internal static void Simulate()
        {
            PrepareSimulation();
            StartSimulation();
        }

        internal static void PrepareSimulation()
        {
            Hospital hospital = new Hospital();
            Randomizer birthAndTypeDwarf = new Randomizer();
            for (int index = 0; index < 10; index++)
            {
                DwarfTypes dwarfTypes = birthAndTypeDwarf.RandomTypeDwarf();
                hospital.CreateNewDwarf(DwarfsPopulation, dwarfTypes, index + 1);

                Raport.TotalBorn++;
            }

            ShaftsNumber.Add(new Shaft());
            ShaftsNumber.Add(new Shaft());
        }

        internal static void StartSimulation()
        {
            for (int daysCount = 0; daysCount < 30; daysCount++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"#### Day {daysCount + 1} ####");
                Console.ResetColor();

                if (DayOfWork()) break;
                Console.WriteLine("");
                Console.ReadKey();

            }

            Raport.EndGameStats().ToList().ForEach(a => Console.WriteLine(a));
        }

        internal static bool DayOfWork()
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