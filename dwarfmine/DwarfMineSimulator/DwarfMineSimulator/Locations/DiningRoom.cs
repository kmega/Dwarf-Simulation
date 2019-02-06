using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DwarfMineSimulator
{
    internal class DiningRoom
    {
        internal int DwarfsEat(int Food, List<Dwarf> dwarfes)
        {
            int foodConsumed = dwarfes.Where(dwarf => dwarf.MoneyEarndedThisDay > 0).Count();
            Food = Food - foodConsumed;
            return OrderFood(Food);
        }

        int OrderFood(int Food)
        {
            if (Food<10)  return Food + 30;

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
