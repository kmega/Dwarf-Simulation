using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Market
{
	class BuyAlcoholAction : IShopAction
	{
		public void BuyProdcutsFromMarket(decimal dailySalary, Market market)
		{
			decimal spentMoney = dailySalary / 2;

			decimal amountOfAlcohol = market.marketState[E_ProductsType.Alcohol];
			amountOfAlcohol += spentMoney;
			market.marketState[E_ProductsType.Alcohol] = amountOfAlcohol;
		}
	}
}
