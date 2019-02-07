using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Locations.Bank;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class Market 
	{
		public BankAccount shopMoneyAccount = new BankAccount();
		public Dictionary<E_ProductsType, decimal> marketState = new Dictionary<E_ProductsType, decimal>();

		public Market()
		{
			marketState.Add(E_ProductsType.Food, 0);
			marketState.Add(E_ProductsType.Alcohol, 0);
		}
		
		public void PerformShopping(List<Dwarf> customers, GeneralBank bank)
		{
			foreach (var customer in customers)
			{
				if (customer.DwarfType == E_DwarfType.Dwarf_Single)
				{
					BuyProdcutsFromMarket(customer, E_ProductsType.Alcohol, bank);
				}
				else if (customer.DwarfType == E_DwarfType.Dwarf_Father)
				{
					BuyProdcutsFromMarket(customer, E_ProductsType.Food, bank);
				}
			}
		}

		public void BuyProdcutsFromMarket(Dwarf customer, E_ProductsType productType, GeneralBank bank)
		{
			decimal recipe = customer.BankAccount.LastInput / 2;

			decimal amountOfProduct = marketState[productType];
			amountOfProduct += recipe;
			marketState[productType] = amountOfProduct;

			bank.PayTax(recipe);

			shopMoneyAccount.ReceivedMoney(recipe * 0.77m);
			shopMoneyAccount.CalculateOverallAccount();
		}
	}
}
