namespace DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer
{
    public interface IIsDwarfBornRandomizer : IRandomizer
    {
        int Generate(int minValue, int maxValue);
    }
}