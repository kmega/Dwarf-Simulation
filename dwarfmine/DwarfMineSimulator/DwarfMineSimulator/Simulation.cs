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

        internal static  int MithrilMinded { get; set; } = 0;
        internal static  int GoldMinded { get; set; } = 0;
        internal static  int SilverMinded { get; set; } = 0;
        internal static int TaintedGoldMinded { get; set; } = 0;

        internal static int DeathCount { get; set; } = 0;

        internal static  decimal TaxedMoney { get; set; } = 0.0m;
        internal static decimal TotalMoneyEarned { get; set; } = 0.0m;

        internal static  int FoodEaten { get; set; } = 0;
        internal static int FoodInDiningRoom { get; set; } = 200;

        internal static  int FoodBought { get; set; } = 0;
        internal static int AlcoholBought { get; set; } = 0;

        internal static List<Dwarf> DwarfsPopulation = new List<Dwarf>();


        internal static void Simulate()
        {
            PrepareSimulation();
            StartSimulation();
        }

        internal static void PrepareSimulation()
        {
            // Add ten dwarfs to lists.
        }

        internal static void StartSimulation()
        {
            for (int daysCount = 0; daysCount < 30; daysCount++)
            {
                DayOfWork();
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
            // F

            Guild guild = new Guild();
            // F
            guild.HowMuchDwarfEarnedMoney(DwarfsPopulation);

            DiningRoom diningRoom = new DiningRoom();
            // F

            Shop shop = new Shop();
            // F
        }
    }
}