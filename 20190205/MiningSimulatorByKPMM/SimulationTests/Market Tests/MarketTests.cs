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
		GeneralBank bank;

		[SetUp]
		public void Setup()
		{
			market = new Market();
			bank = new GeneralBank();
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
		//	market.PerformShopping(dwarfsList, bank);
			decimal result = market.marketState[E_ProductsType.Food];

			//then
			Assert.AreEqual(50, result);
		}

		[Test]
		public void ShouldGive23ByTaxToBankAccount()
		{
			//given
			
			List<Dwarf> dwarfsList = new List<Dwarf>();
			Dwarf Andrzej = new Dwarf(E_DwarfType.Dwarf_Father);
			Andrzej.BankAccount.ReceivedMoney(200);
			dwarfsList.Add(Andrzej);
			//when 
		//	market.PerformShopping(dwarfsList, bank);
			decimal result = bank.BankTresure();

			//then
			Assert.AreEqual(23, result);
		}

		[Test]
		public void ShouldBeSold300AlcoholAnd300Food()
		{
			//given
			FakeDwarfsListForTest fakeListDwawrfs = new FakeDwarfsListForTest();
			List<Dwarf> dwarfsList = fakeListDwawrfs.FakeList();

			//when
		//	market.PerformShopping(dwarfsList, bank);
			decimal result1 = market.marketState[E_ProductsType.Food];
			decimal result2 = market.marketState[E_ProductsType.Alcohol];
			

			//then
			Assert.AreEqual(300, result1);
			Assert.AreEqual(300, result2);
		}

		[Test]
		public void MarketAccountShouldHaveSomeMoneyAlsoBankAccount()
		{
			//given
			FakeDwarfsListForTest fakeListDwawrfs = new FakeDwarfsListForTest();
			List<Dwarf> dwarfsList = fakeListDwawrfs.FakeList();

			//when
		//	market.PerformShopping(dwarfsList, bank);

			decimal result1 = market.shopMoneyAccount.OverallAccount;
			decimal result2 = bank.BankTresure();

			//then
			Assert.AreEqual(462, result1);
			Assert.AreEqual(138, result2);
		}

		[Test]
		public void AccountOfDwarfShouldBeLessByRecipeFromShop()
		{
			//given
			List<Dwarf> dwarfsList = new List<Dwarf>();
			Dwarf Andrzej = new Dwarf(E_DwarfType.Dwarf_Father);
			Andrzej.BankAccount.ReceivedMoney(200);
			dwarfsList.Add(Andrzej);

			//when
		//	market.PerformShopping(dwarfsList, bank);
			Andrzej.BankAccount.CalculateOverallAccount();
			decimal result = Andrzej.BankAccount.OverallAccount;
			//then
			Assert.AreEqual(100, result);
		}

	}
}
