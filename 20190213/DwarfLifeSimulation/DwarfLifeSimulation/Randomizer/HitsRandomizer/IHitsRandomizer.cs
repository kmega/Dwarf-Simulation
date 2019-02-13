namespace DwarfLifeSimulation.Randomizer.HitsRandomizer
{
    public interface IHitsRandomizer : IRandomizer
    {
        int HowManyHits(int min = 1, int max = 3);
    }
}