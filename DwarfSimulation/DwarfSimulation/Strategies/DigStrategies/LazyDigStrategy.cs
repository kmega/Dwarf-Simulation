namespace DwarfSimulation
{
    class LazyDigStrategy : IDig
    {
        public int Dig(Mines mines, Randomizer randomizer)
        {
            int number = randomizer.ReturnFromTo(0, 1);

            return number;
        }
    }
}
