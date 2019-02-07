using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.PersonalItems;
using NUnit.Framework;
using MiningSimulatorByKPMM.DwarfsTypes;

namespace SimulationTests.Market_Tests
{
	public class MarketTests
	{
		Market market;

		[SetUp]
		public void Setup()
		{
			market = new Market();
		}

		[Test]
		public void ShouldBe0eachProductInMerket()
		{
			//given

			//when
			decimal result1 = market.marketState[E_ProductsType.Alcohol];
			decimal result2 = market.marketState[E_ProductsType.Food];

			//then
			Assert.AreEqual(0, result1);
			Assert.AreEqual(0, result2);
		}

		[Test]
		public void ShopAccountShouldBe0()
		{
			//given
			//when
			decimal result = market.shopMoneyAccount.OverallAccount;
			//then
			Assert.AreEqual(0, result);
		}

		[Test]
		public void MarketShouldHave50foodSoldInMarketState()
		{
			//given
			List<Dwarf> dwarfsList = new List<Dwarf>();
			Dwarf Andrzej = new Dwarf(E_DwarfType.Dwarf_Father);
			Andrzej.BankAccount.ReceivedMoney(100);
			dwarfsList.Add(Andrzej);

			//when
			market.PerformShopping(dwarfsList);
			decimal result = market.marketState[E_ProductsType.Food];

			//then
			Assert.AreEqual(50, result);
		}

	}
}
