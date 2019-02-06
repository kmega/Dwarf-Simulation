using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketTests
{
	[TestClass]
	public class MarketTests
	{
		//SetUp?

		[TestMethod]
		public void AmountOfFoodShouldBe0InMarketState()
		{
			//given
			Market marketTest = new Market();
			//when
			decimal expected = marketTest.marketState[E_ProductsType.Food];
			//then
			Assert.AreEqual(0, expected);
		}

		[TestMethod]
		public void AmountOfAlcoholShouldBe0InMarketState()
		{
			//given
			Market marketTest = new Market();
			//when
			decimal expected = marketTest.marketState[E_ProductsType.Alcohol];
			//then
			Assert.AreEqual(0, expected);
		}

		[TestMethod]
		public void OneFatherBuyProductsFromMarketHeHas50DailySalary()
		{
			//given
			Market marketTest = new Market();
			//when
			marketTest.PerformShopping(50, E_DwarfType.Dwarf_Father);
			decimal expected = marketTest.marketState[E_ProductsType.Food];
			//then
			Assert.AreEqual(25, expected);
		}


	}
}

