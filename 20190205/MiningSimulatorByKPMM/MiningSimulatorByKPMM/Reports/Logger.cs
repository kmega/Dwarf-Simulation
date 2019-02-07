using MiningSimulatorByKPMM.ApplicationLogic;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Locations.Mine.Miningoutputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Reports
{
    public sealed class Logger : ILogger
    {
        List<string> Logs;
        private IOutputWriter outputWriter;

        private Logger()
        {
            Logs = new List<string>();
            outputWriter = new ConsoleWriter();
        }
        private static Logger instance = null;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
        public void AddLog(string message)
        {
            Logs.Add(message);
            outputWriter.Display(message);
        }

        public void GenerateReport(SimulationState finalState)
        {
            DisplayDeadDwarves(finalState.NumberOfDeadDwarves);
            DisplayMiningSummary(finalState.extractedOre);
            //DisplayShopSummary(finalState.)
            DisplayHospitalBirths(finalState.NumberOfBirths);
            DisplayGuildBankState(finalState.guildBankAccount);
            DisplayTaxBankState(finalState.taxBankAccount);
        }
    }
}
