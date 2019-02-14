using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Randomizer.MineralValueRandomizer
{
    public interface IMineralValueRandomizer
    {
        decimal ExchangeMineralToValue(MineralType mineralType);
    }
}