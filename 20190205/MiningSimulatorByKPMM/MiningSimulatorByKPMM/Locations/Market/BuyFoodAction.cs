using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.Locations;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class BuyFoodAction : IShopAction
	{
		public void BuyProdcutsFromMarket(Dwarf shopCustomer)
		{
			decimal amoutOfFood = shopCustomer.SpendMoney();
			Market.marketState.Add(Enums.E_ProductsType.Food, amoutOfFood);
		}
	}
}
