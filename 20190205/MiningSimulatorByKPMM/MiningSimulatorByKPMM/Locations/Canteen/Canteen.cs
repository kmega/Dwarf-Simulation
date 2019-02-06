using MiningSimulatorByKPMM.DwarfsTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Canteen
{
    public class Canteen
    {
        public int FoodRations { get; set; }

        public void GiveFoodRations(List<Dwarf> dwarfs)
        {
            var numberOfRationsToGive = dwarfs.Count;
            FoodRations -= numberOfRationsToGive;
        }

        public void OrderFoodRations()
        {
            if (FoodRations < 10)
            {
                this.FoodRations += 30;
            }
        }
    }
}