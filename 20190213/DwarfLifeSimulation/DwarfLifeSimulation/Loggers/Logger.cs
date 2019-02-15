using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.ApplicationLogic;

namespace DwarfLifeSimulation.Loggers
{
	public class Logger : ILog
	{
		List<string> Logs;
		public IComment outputWriter;

		public Logger()
		{
			Logs = new List<string>();
			outputWriter = new Commentator();
		}


		public void AddLog(string message)
		{
			var finalMessage = $"[{DateTime.Now}] {message}";
			Logs.Add(finalMessage);
			outputWriter.Display(finalMessage);
		}

		public void DisplayReport(SimulationState state)
		{
			Console.WriteLine("**********************************************");
			Console.WriteLine("**************** DWARVES NEWS ****************");
			Console.WriteLine();
			Console.WriteLine("Ladies and Getlemans, we present summary report");
			Console.WriteLine("            for whole simulation:");
			Console.WriteLine();
			DisplayHospitalBirths(state._numberOfBirths);
			DisplayMiningSummary(state._extractedOre);
			DisplayShopSummary(state._shopState);
			DisplayShopBankState(state._shopBankAccount);
			DisplayGuildBankState(state._guildBankAccount);
			DisplayTaxSummaryInBank(state._taxBankAccount);
			DisplayDeadDwarves(state._deadDwarves);
			Console.WriteLine("**********************************************");
		}

		private void DisplayHospitalBirths(int numberOfBirths)
		{
			outputWriter.Display($"Total births: {numberOfBirths};");
			Console.WriteLine();
		}

		private void DisplayMiningSummary(Dictionary<MineralType, decimal[]> extractedOre)
		{
			foreach (var val in extractedOre.Keys)
			{
				outputWriter.Display($"{val.ToString()} mined in {extractedOre[val][0]} units, for total value {extractedOre[val][1]};");
			}
			Console.WriteLine();
		}

		private void DisplayDeadDwarves(int numberOfDeadDwarves)
		{
			outputWriter.Display($"During simulation {numberOfDeadDwarves} died in Mine. For glory of mighty Dain Ironfoot!");
			Console.WriteLine();
		}

		private void DisplayShopSummary(Dictionary<ProductType, decimal> shopState)
		{
			outputWriter.Display("Shop sold:");

			foreach (var product in shopState)
			{
				if (product.Key != ProductType.None)
				{
					outputWriter.Display($"- {product.Key}: {product.Value};");
				}
			}
			Console.WriteLine();
		}

		private void DisplayShopBankState(decimal shopBankAccount)
		{
			outputWriter.Display($"Shop have {shopBankAccount} gp on account;");
			Console.WriteLine();
		}

		private void DisplayTaxSummaryInBank(decimal taxBankAccount)
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
