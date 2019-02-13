namespace DwarfLifeSimulation.Randomizer.DwarfNameRandomizer
{
    public interface IDwarfNameRandomizer : IRandomizer
    {
         int Generate(int minValue, int maxValue);
    }
}