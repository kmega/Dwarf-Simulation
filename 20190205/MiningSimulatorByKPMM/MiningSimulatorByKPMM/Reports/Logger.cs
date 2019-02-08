﻿using MiningSimulatorByKPMM.ApplicationLogic;
using MiningSimulatorByKPMM.Enums;
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
        public IOutputWriter outputWriter;

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

        public void DisplayReport(SimulationState finalState)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            DisplayDeadDwarves(finalState.NumberOfDeadDwarves);
            DisplayMiningSummary(finalState.ExtractedOre);
            DisplayShopSummary(finalState.MarketState);
            DisplayHospitalBirths(finalState.NumberOfBirths);
            DisplayGuildBankState(finalState.GuildBankAccount);
            DisplayTaxBankState(finalState.TaxBankAccount);
        }

        private void DisplayHospitalBirths(int numberOfBirths)
        {
            outputWriter.Display($"Total births: {numberOfBirths};");
            Console.WriteLine();
        }

        private void DisplayMiningSummary(Dictionary<E_Minerals, int> extractedOre)
        {
           foreach(E_Minerals val in Enum.GetValues(typeof(E_Minerals)))
            {
                outputWriter.Display($"{val.ToString()} mined in {extractedOre[val]} units;");
            }
            Console.WriteLine();
        }

        private void DisplayDeadDwarves(int numberOfDeadDwarves)
        {
            outputWriter.Display($"During simulation {numberOfDeadDwarves} died in Mine. We are truly sorry.");
            Console.WriteLine();
        }

        private void DisplayShopSummary(Dictionary<E_ProductsType, decimal> marketState)
        {
            outputWriter.Display("Market sold:");
            foreach (var product in marketState)
            {
                outputWriter.Display($"{product.Key}: {product.Value};");
               
            }
            Console.WriteLine();
        }

        private void DisplayTaxBankState(decimal taxBankAccount)
        {
            outputWriter.Display($"Bank have {taxBankAccount} gp on account;");
            Console.WriteLine();
        }

        private void DisplayGuildBankState(decimal guildBankAccount)
        {
            outputWriter.Display($"Guild have {guildBankAccount} gp on account;");
            Console.WriteLine();
        }




    }
}
