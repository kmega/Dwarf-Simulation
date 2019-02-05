using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Market
{
	class BuyAlcoholAction : IShopAction
	{
		public void BuyProdcutsFromMarket(Dwarf shopCustomer)
		{
			decimal amountOfAlcohol = shopCustomer.SpendMoney();
			Market.marketState.Add(Enums.E_ProductsType.Alcohol, amoutOfFood);
		}
	}
}
