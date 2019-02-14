using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Locations.Canteens;

namespace DwarfLifeSimulationsTests.CanteenTests
{
	public class TestsForCanteen
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void T201CanteenShouldHave190PortionsAfterServe()
		{
			//given
			Canteen McDonald = new Canteen();
			int amountOfPortion = 10;

			//when
			McDonald.ServeMultipleRations(amountOfPortion);
			int result = McDonald.GetAmountOfRations();

			//then
			Assert.AreEqual(190, result);
		}

		[Test]
		public void T202CanteenShouldOrderRationsWhenBelow10()
		{
			//given
			Canteen McDonald = new Canteen();
			int amountOfPortion = 190;

			//when
			McDonald.ServeMultipleRations(amountOfPortion);
			int result = McDonald.GetAmountOfRations();

			//then
			Assert.AreEqual(40, result);
		}
		
	}
}
