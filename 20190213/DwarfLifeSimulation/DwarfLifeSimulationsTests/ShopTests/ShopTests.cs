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
		public void _501ShopStateShouldContainsEachProduct()
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
		public void _502ShouldBe0EachProductInShopState()
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
		public void _503WhenDwarfFatherBuyShouldBeInShopStateMoreFoodBought()
		{
			//given
			Dwarf testDwarf = new Dwarf("Gloin", new StandardWorkStrategy(), new BuyFoodStrategy());
			Shop shop = new Shop();
			
			//when
			
			//then

		}
	}
}
