using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;

namespace DwarfLifeSimulation.Dwarves
{
    public interface IDwarf : IWork, IBuy, IExchange
    {
        DwarfType _dwarfType { get; }
    }
}
