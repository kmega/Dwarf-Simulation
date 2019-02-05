using System;
using System.Collections.Generic;

namespace DwarfMineSimulator
{
    internal class Simulation
    {
        int LazyBorn { get; set; } = 0;
        int SingleBorn { get; set; } = 0;
        int FatherBorn { get; set; } = 0;
        int SuiciderBorn { get; set; } = 0;
        int TotalBorn { get; set; } = 0;

        int MithrilMinded { get; set; } = 0;
        int GoldMinded { get; set; } = 0;
        int SilverMinded { get; set; } = 0;
        int TaintedGoldMinded { get; set; } = 0;

        int DeathCount { get; set; } = 0;

        decimal TaxedMoney { get; set; } = 0.0m;
        decimal TotalMoneyEarned { get; set; } = 0.0m;

        int FoodEaten { get; set; } = 0;

        int FoodBought { get; set; } = 0;
        int AlcoholBought { get; set; } = 0;

        List<Dwarf> DwarfsPopulation = new List<Dwarf>();

        internal void Simulate()
        {
            PrepareSimulation();
            StartSimulation();
        }

        internal void PrepareSimulation()
        {
            // Add ten dwarfs to lists.
        }

        internal void StartSimulation()
        {
            for (int daysCount = 0; daysCount < 30; daysCount++)
            {
                DayOfWork();
            }
        }

        private void DayOfWork()
        {
            Hospital hospital = new Hospital();
            // F

            Mines mines = new Mines();
            // F

            Graveyard graveyard = new Graveyard();
            // F

            Guild guild = new Guild();
            // F

            DiningRoom diningRoom = new DiningRoom();
            // F

            Shop shop = new Shop();
            // F
        }
    }
}