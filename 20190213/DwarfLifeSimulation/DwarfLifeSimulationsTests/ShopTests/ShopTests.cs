﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DwarfLifeSimulation.Locations.Shops;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using System.Linq;

namespace DwarfLifeSimulationsTests.ShopTests
{
	public class BankMock : Bank
	{
		public static void ResetInstace()
		{
			instance = null;
		}
	}

	public class ShopTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void T501_ShopStateShouldContainsEachProduct()
		{
			//given
			Shop testShop = new Shop();

			//when
			var result1 = testShop._shopState.ContainsKey(ProductType.Alcohol);
			var result2 = testShop._shopState.ContainsKey(ProductType.Food);

			//then
			Assert.IsTrue(result1);
			Assert.IsTrue(result2);

		}

		[Test]
		public void T502_ShouldBe0EachProductInShopState()
		{
			//given
			Shop testShop = new Shop();

			//when
			var result1 = testShop._shopState[ProductType.Food];
			var result2 = testShop._shopState[ProductType.Alcohol];

			//then
			Assert.AreEqual(0, result1);
			Assert.AreEqual(0, result2);
			
		}

		[Test]
		public void T503_WhenDwarfBuyHeShouldPay50OfHisDailyIncomeToShopAccount()
		{
			//given
			BankMock.ResetInstace();
			IDwarf testDwarf = new DwarfFactory().Create(DwarfType.Father);
			Shop shop = new Shop();
			Bank.Instance.PayIntoAccount(1, 100m);

			//when
			shop.ServeSingleCustomer(testDwarf);
			decimal result1 = Bank.Instance.GetDailyIncome(1);
			decimal result2 = Bank.Instance.GetDailyIncome(2);

			//then
			Assert.AreEqual(50m, result1);
			Assert.AreEqual(50m, result2);
		}

		[Test]
		public void T504_DwarfsFatherAndSingleShouldSpendHalfOfTheyMoneyToShopAccountAnd23percentageShoulgGoToBankTaxAccount()
		{
			//given
			BankMock.ResetInstace();
			IDwarf testDwarf1 = new DwarfFactory().Create(DwarfType.Single);
			IDwarf testDwarf2 = new DwarfFactory().Create(DwarfType.Father);
			IDwarf testDwarf3 = new DwarfFactory().Create(DwarfType.Single);
			IDwarf testDwarf4 = new DwarfFactory().Create(DwarfType.Father);
			Shop shop = new Shop();
			BankMock.Instance.PayIntoAccount(1, 100);
			BankMock.Instance.PayIntoAccount(2, 200);
			BankMock.Instance.PayIntoAccount(3, 400);
			BankMock.Instance.PayIntoAccount(4, 600);
			List<IBuy> testListOfDwarves = new List<IBuy>() { testDwarf1, testDwarf2, testDwarf3, testDwarf4 };

			//when
			shop.ServeAllCustomers(testListOfDwarves);
			decimal result1 = Bank.Instance.GetDailyIncome(1);
			decimal result2 = Bank.Instance.GetDailyIncome(2);
			decimal result3 = Bank.Instance.GetDailyIncome(3);
			decimal result4 = Bank.Instance.GetDailyIncome(4);

			//then
			Assert.AreEqual(50, result1);
			Assert.AreEqual(100, result2);
			Assert.AreEqual(200, result3);
			Assert.AreEqual(300, result4);
		}

		[Test]
		public void T505_Service2CustomersShopStateShouldHave50AlcoholAnd50FoodInIt()
		{
			//given
			BankMock.ResetInstace();
			IDwarf testDwarf1 = new DwarfFactory().Create(DwarfType.Single);
			IDwarf testDwarf2 = new DwarfFactory().Create(DwarfType.Father);
			Shop shop = new Shop();
			BankMock.Instance.PayIntoAccount(1, 246);
			BankMock.Instance.PayIntoAccount(2, 200);
			List<IBuy> testListOfDwarves = new List<IBuy>() { testDwarf1, testDwarf2 };

			//when
			shop.ServeAllCustomers(testListOfDwarves);
			decimal result1 = shop._shopState[ProductType.Alcohol];
			decimal result2 = shop._shopState[ProductType.Food];

			//then
			Assert.AreEqual(123, result1);
			Assert.AreEqual(100, result2);
		}

		[Test]
		public void T506_SluggardAndSuicidersShouldNotBuyAnythingAndOneSingleShouldBuyAlcohol()
		{
			//given
			BankMock.ResetInstace();
			IDwarf testDwarf1 = new DwarfFactory().Create(DwarfType.Sluggard);
			IDwarf testDwarf2 = new DwarfFactory().Create(DwarfType.Father);
			IDwarf testDwarf3 = new DwarfFactory().Create(DwarfType.Suicide);
			IDwarf testDwarf4 = new DwarfFactory().Create(DwarfType.Single);
			Shop shop = new Shop();
			BankMock.Instance.PayIntoAccount(1, 100);
			BankMock.Instance.PayIntoAccount(2, 200);
			BankMock.Instance.PayIntoAccount(3, 400);
			BankMock.Instance.PayIntoAccount(4, 600);
			List<IBuy> testListOfDwarves = new List<IBuy>() { testDwarf1, testDwarf2, testDwarf3, testDwarf4 };

			//when
			shop.ServeAllCustomers(testListOfDwarves);
			decimal result1 = Bank.Instance.GetDailyIncome(1);
			decimal result2 = Bank.Instance.GetDailyIncome(2);
			decimal result3 = Bank.Instance.GetDailyIncome(3);
			decimal result4 = Bank.Instance.GetDailyIncome(4);
			decimal alcoholSold = shop._shopState[ProductType.Alcohol];
			decimal foodSold = shop._shopState[ProductType.Food];
			decimal shopAccount = Bank.Instance.GetDailyIncome(5);

			//then
			Assert.AreEqual(100, result1);
			Assert.AreEqual(100, result2);
			Assert.AreEqual(400, result3);
			Assert.AreEqual(300, result4);
			Assert.AreEqual(300, alcoholSold);
			Assert.AreEqual(100, foodSold);
			Assert.AreEqual(308, shopAccount);
		}
	}
}
