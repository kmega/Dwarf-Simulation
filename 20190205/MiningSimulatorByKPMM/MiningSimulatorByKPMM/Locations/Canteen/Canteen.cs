using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Canteen
{
    public class Canteen
    {
        public int FoodRations { get; set; }
        private ILogger _logger;

        public Canteen()
        {
            _logger = Logger.Instance;
        }

        public void GiveFoodRations(int dwarfs)
        {
            var numberOfRationsToGive = dwarfs;
            _logger.AddLog($"{numberOfRationsToGive} food rations were served");
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