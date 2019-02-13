using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralTypeRandomizer
{
    public interface IMineralTypeRandomizer : IRandomizer
    {
        int Generate(int minValue, int maxValue);
    }
}