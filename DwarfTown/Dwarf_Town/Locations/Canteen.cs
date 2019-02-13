using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations
{
    public class Canteen
    {
        public Canteen(int foodRations)
        {
            FoodRations = foodRations;
        }
        public int FoodRations { get; set; }

        public void SpendFoodRations(IList<Dwarf> dwarves)
        {
            FoodRations -= dwarves.Count;
        }

        public void OrderFoodRations()
        {
            if (FoodRations < 10)
            {
                FoodRations += 30;
            }
        }
    }
}
