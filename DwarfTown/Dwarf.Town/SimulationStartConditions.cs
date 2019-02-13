namespace Dwarf.Town
{
    public class SimulationStartConditions
    {
        private readonly int _dwarvesAtStart;
        private readonly int _rounds;
        private readonly int _foodRationsAtStart;

        public SimulationStartConditions(int dwarvesAtStart, int rounds, int foodRationsAtStart)
        {
            _dwarvesAtStart = dwarvesAtStart;
            _rounds = rounds;
            _foodRationsAtStart = foodRationsAtStart;

        }

        
    }
}