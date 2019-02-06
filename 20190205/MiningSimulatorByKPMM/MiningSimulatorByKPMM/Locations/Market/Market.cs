using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class Market 
	{
		public Market()
		{
			marketState.Add(E_ProductsType.Food, 0);
			marketState.Add(E_ProductsType.Alcohol, 0);
			shopBankAccount = 0;
		}

		private decimal shopBankAccount;
		public Dictionary<E_ProductsType, decimal> marketState = new Dictionary<E_ProductsType, decimal>();
		
		public void PerformShopping(List<Dwarf> customers)
		{
			foreach (var customer in customers)
			{
				if (customer.DwarfType == E_DwarfType.Dwarf_Single)
				{
					BuyProdcutsFromMarket(dailySalary, this, E_ProductsType.Alcohol);
				}
				else if (customer.DwarfType == E_DwarfType.Dwarf_Father)
				{
					BuyProdcutsFromMarket(dailySalary, this, E_ProductsType.Food);
				}
			}
		}

		public void BuyProdcutsFromMarket(decimal dailySalary, Market market, E_ProductsType productType, Bank bank)
		{
			decimal spentMoney = dailySalary / 2;
			decimal amountOfProduct = market.marketState[productType];
			amountOfProduct += spentMoney;
			market.marketState[productType] = amountOfProduct;
			decimal tax = bank.PayTax(spentMoney);
			bank.PayIntoYourAccount(shopBankAccount, spentMoney - tax);
		}
	}
}
