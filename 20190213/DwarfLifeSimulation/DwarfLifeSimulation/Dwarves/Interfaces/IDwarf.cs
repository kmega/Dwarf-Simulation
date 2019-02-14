using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IDwarf : IWork, IBuy, IExchange
    {
        DwarfType _dwarfType { get; }
    }
}
