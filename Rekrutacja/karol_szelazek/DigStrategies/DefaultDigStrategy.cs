namespace DwarfSimulation
{
    class DefaultDigStrategy : IDig
    {
        private Randomizer _randomizer = new Randomizer();

        public int Dig()
        {
            int number = _randomizer.ReturnFromTo(1, 3);

            return number;
        }
    }
}
