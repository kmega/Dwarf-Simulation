using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Market
{
	public class Market 
	{
		public static Dictionary<E_ProductsType, decimal> marketState = new Dictionary<E_ProductsType, decimal>();

		public void PerformShopping(List<Dwarf> dwarvesList)
		{
			foreach (Dwarf customer in dwarvesList)
			{
				BuyProdcutsFromMarket(customer);
			}
		}
	}
}
