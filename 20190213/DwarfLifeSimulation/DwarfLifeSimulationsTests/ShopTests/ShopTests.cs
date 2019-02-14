using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DwarfLifeSimulation.Locations.Shops;
using DwarfLifeSimulation.Enums;
using System.Linq;
using DwarfLifeSimulation.Locations.Banks;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.Interfaces;

namespace DwarfLifeSimulationsTests.ShopTests
{
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
			Dwarf testDwarf = new Dwarf("Gloin", DwarfType.Father, new StandardWorkStrategy(), new BuyFoodStrategy());
			Shop shop = new Shop();
			Bank.Instance.PayIntoAccount(1, 100);

			//when
			shop.ServeSingleCustomer(testDwarf);
			decimal result1 = Bank.Instance.GetDailyIncome(1);
			decimal result2 = Bank.Instance.GetDailyIncome(2);

			//then
			Assert.AreEqual(50, result1);
			Assert.AreEqual(50, result2);
		}

		[Test]
		public void T504_DwarfsFatherAndSingleShouldSpendHalfOfTheyMoneyToShopAccountAnd23percentageShoulgGoToBankTaxAccount()
		{
			//given
			Dwarf testDwarf1 = new Dwarf("Thorin", DwarfType.Single, new StandardWorkStrategy(), new BuyAlcoholStrategy());
			Dwarf testDwarf2 = new Dwarf("Gloin", DwarfType.Father, new StandardWorkStrategy(), new BuyFoodStrategy());
			Dwarf testDwarf3 = new Dwarf("Gimli", DwarfType.Single, new StandardWorkStrategy(), new BuyAlcoholStrategy());
			Dwarf testDwarf4 = new Dwarf("Balin", DwarfType.Father, new StandardWorkStrategy(), new BuyFoodStrategy());
			Shop shop = new Shop();
			Bank.Instance.PayIntoAccount(1, 100);
			Bank.Instance.PayIntoAccount(2, 200);
			Bank.Instance.PayIntoAccount(3, 400);
			Bank.Instance.PayIntoAccount(4, 600);
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
			Dwarf testDwarf1 = new Dwarf("Thorin", DwarfType.Single, new StandardWorkStrategy(), new BuyAlcoholStrategy());
			Dwarf testDwarf2 = new Dwarf("Gloin", DwarfType.Father, new StandardWorkStrategy(), new BuyFoodStrategy());
			Shop shop = new Shop();
			Bank.Instance.PayIntoAccount(1, 246);
			Bank.Instance.PayIntoAccount(2, 200);
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
			Dwarf testDwarf1 = new Dwarf("Thorin", DwarfType.Sluggard, new StandardWorkStrategy(), new BuyNoneStrategy());
			Dwarf testDwarf2 = new Dwarf("Gloin", DwarfType.Father, new StandardWorkStrategy(), new BuyFoodStrategy());
			Dwarf testDwarf3 = new Dwarf("Gimli", DwarfType.Suicide, new SuicideStrategy(), new BuyNoneStrategy());
			Dwarf testDwarf4 = new Dwarf("Balin", DwarfType.Single, new StandardWorkStrategy(), new BuyAlcoholStrategy());
			Shop shop = new Shop();
			Bank.Instance.PayIntoAccount(1, 100);
			Bank.Instance.PayIntoAccount(2, 200);
			Bank.Instance.PayIntoAccount(3, 400);
			Bank.Instance.PayIntoAccount(4, 600);
			List<IBuy> testListOfDwarves = new List<IBuy>() { testDwarf1, testDwarf2, testDwarf3, testDwarf4 };

			//when
			shop.ServeAllCustomers(testListOfDwarves);
			decimal result1 = Bank.Instance.GetDailyIncome(1);
			decimal result2 = Bank.Instance.GetDailyIncome(2);
			decimal result3 = Bank.Instance.GetDailyIncome(3);
			decimal result4 = Bank.Instance.GetDailyIncome(4);
			decimal alcoholSold = shop._shopState[ProductType.Alcohol];
			decimal foodSold = shop._shopState[ProductType.Food];
			decimal shopAccount = Bank.Instance.GetOverallAccountMoney(5);

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
