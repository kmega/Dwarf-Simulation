using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralValueRandomizer
{
    public interface IMineralValueRandomizer : IRandomizer
    {
        decimal ExchangeMineralToValue(MineralType mineralType);
    }
}