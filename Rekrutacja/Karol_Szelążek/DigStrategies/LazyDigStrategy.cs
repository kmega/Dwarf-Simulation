namespace DwarfSimulation
{
    class LazyDigStrategy : IDig
    {
        private Randomizer _randomizer = new Randomizer();

        public int Dig()
        {
            int number = _randomizer.ReturnFromTo(0, 1);

            return number;
        }
    }
}
