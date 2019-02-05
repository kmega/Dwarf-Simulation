using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Interfaces;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;

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
	}
}

