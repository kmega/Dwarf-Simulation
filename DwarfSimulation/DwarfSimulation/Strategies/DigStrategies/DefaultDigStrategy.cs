namespace DwarfSimulation
{
    class DefaultDigStrategy : IDig
    {
        public int Dig(Mines mines, Randomizer randomizer)
        {
            int number = randomizer.ReturnFromTo(1, 3);

            return number;
        }
    }
}
