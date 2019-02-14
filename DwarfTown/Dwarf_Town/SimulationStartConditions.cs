namespace Dwarf_Town
{
    public class SimulationStartConditions
    {
        public int DwarvesAtStart { get; private set; }
        public int Rounds { get; private set; }
        public int FoodRationsAtStart { get; private set; }

        public SimulationStartConditions(int dwarvesAtStart, int rounds, int foodRationsAtStart)
        {
            DwarvesAtStart = dwarvesAtStart;
            Rounds = rounds;
            FoodRationsAtStart = foodRationsAtStart;
        }
    }
}