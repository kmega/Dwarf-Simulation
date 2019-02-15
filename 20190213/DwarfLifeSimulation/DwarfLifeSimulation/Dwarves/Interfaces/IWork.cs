using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves.Interfaces
{
    public interface IWork
    {
        bool _hasWorked { get; set; }
        bool _isAlive { get; set; }
        void Work(Shaft shaft, ILog logger);
    }
}
