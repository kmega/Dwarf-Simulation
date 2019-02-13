namespace DwarfLifeSimulation.Randomizer.MineralValueRandomizer
{
    public interface IMineralValueRandomizer : IRandomizer
    {
        int Generate(int minValue, int maxValue);
    }
}