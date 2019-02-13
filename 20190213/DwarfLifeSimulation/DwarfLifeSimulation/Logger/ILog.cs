using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Logger
{
    public interface ILog
    {
        void AddLog(string message);
        void DisplayReport();
    }
}
