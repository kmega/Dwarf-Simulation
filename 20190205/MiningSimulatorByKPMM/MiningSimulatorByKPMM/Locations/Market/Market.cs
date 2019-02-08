using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Reports;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class Market 
	{
		private ILogger _logger;
		public BankAccount _shopMoneyAccount = new BankAccount();
		public Dictionary<E_ProductsType, decimal> _marketState = new Dictionary<E_ProductsType, decimal>();

		public Market()
		{
			_logger = Logger.Instance;
			_marketState.Add(E_ProductsType.Food, 0);
			_marketState.Add(E_ProductsType.Alcohol, 0);
		}
		
		public void PerformShopping(List<Dwarf> customers, GeneralBank bank)
		{
			foreach (var customer in customers)
			{
				if (customer.DwarfType == E_DwarfType.Dwarf_Single && customer.IsAlive)
				{
					BuyProdcutsFromMarket(customer, E_ProductsType.Alcohol, bank);
				}
				else if (customer.DwarfType == E_DwarfType.Dwarf_Father && customer.IsAlive)
				{
					BuyProdcutsFromMarket(customer, E_ProductsType.Food, bank);
				}
			}
		}

		public void BuyProdcutsFromMarket(Dwarf customer, E_ProductsType productType, GeneralBank bank)
		{
			decimal recipe = customer.BankAccount.LastInput / 2;

			decimal amountOfProduct = _marketState[productType];
			amountOfProduct += recipe;
			_marketState[productType] = amountOfProduct;

			//updating status of bank accounts of Dwarf, Bank and Market
			customer.BankAccount.Withdraw(recipe);
			bank.PayTax(recipe);
			_shopMoneyAccount.ReceivedMoney(recipe * 0.77m);
			_shopMoneyAccount.CalculateOverallAccount();
			_logger.AddLog($"{customer.DwarfType} has spent {recipe.ToString()} on {productType.ToString()} today.");
		}
	}
}
