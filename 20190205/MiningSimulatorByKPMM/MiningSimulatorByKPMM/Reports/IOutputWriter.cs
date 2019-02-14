using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Reports
{
    public interface IOutputWriter
    {
        void Display(string message);
    }
}
