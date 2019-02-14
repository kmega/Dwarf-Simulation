using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Loggers
{
    public interface ILog
    {
        void AddLog(string message);
        void DisplayReport();
    }
}
