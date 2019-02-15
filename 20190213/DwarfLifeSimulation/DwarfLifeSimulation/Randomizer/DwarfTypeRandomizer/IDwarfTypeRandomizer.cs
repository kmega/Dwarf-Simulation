using DwarfLifeSimulation.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer
{
    public interface IDwarfTypeRandomizer
    {
        DwarfType GiveMeDwarfType(bool omitSuicider = false);
    }
}
