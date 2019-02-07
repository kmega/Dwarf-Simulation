using MiningSimulatorByKPMM.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Reports
{
    public interface ILogger
    {
        void AddLog(string message);
        void GenerateReport(SimulationState finalState);
    }
}
