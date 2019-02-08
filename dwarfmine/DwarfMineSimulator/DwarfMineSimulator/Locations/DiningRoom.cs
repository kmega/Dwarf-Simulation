﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DwarfMineSimulator
{
    internal class DiningRoom
    {
        internal int DwarfsEat(int FoodInDinningRoom, List<Dwarf> dwarfes)
        {
            int foodConsumed = dwarfes.Where(dwarf => dwarf.MoneyEarndedThisDay > 0).Count();
            int lazyDwarfWithoutMoney = dwarfes.Where(dwarf => dwarf.MoneyEarndedThisDay == 0).Count();

            FoodInDinningRoom = FoodInDinningRoom - foodConsumed;

            Console.WriteLine("\n## DINING ROOM ##\n");
            Console.WriteLine("Dwarfs Eats " + foodConsumed + " meals");
            Console.WriteLine("Hungry dwarfs " + lazyDwarfWithoutMoney);
            Console.WriteLine("Food in dining room Food " + FoodInDinningRoom);

            Raport.FoodEaten += foodConsumed; 
            return OrderFood(FoodInDinningRoom);
        }

        int OrderFood(int Food)
        {
            if (Food < 10) return Food + 30;

            return Food;
        }

        internal bool CanEat(int Food, List<Dwarf> dwarfes)
        {
            int foodConsumed = dwarfes.Where(dwarf => dwarf.MoneyEarndedThisDay > 0).Count();

            if (foodConsumed > Food) return false;

            return true;
        }
    }
}
