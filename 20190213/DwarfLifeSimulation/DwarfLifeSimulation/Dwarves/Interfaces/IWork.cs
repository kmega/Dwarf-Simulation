using DwarfLifeSimulation.Locations.Mine;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves
{
    public interface IWork
    {
        void Work(Shaft shaft);
    }
}
