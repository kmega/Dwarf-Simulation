using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.Locations;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class BuyFoodAction : IShopAction
	{
		public void BuyProdcutsFromMarket(decimal dailySalary, Market market)
		{
			decimal spentMoney = dailySalary / 2;

			decimal amountOfFood = market.marketState[E_ProductsType.Food];
			amountOfFood += spentMoney;
			market.marketState[E_ProductsType.Food] = amountOfFood;
		}
	}
}
