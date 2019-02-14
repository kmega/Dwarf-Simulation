using DwarfLifeSimulation.Locations.Banks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulationsTests.BankTests
{
	public class TestsForBank
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void T601_ShouldCreate1AccountAndHaveItInDictionary()
		{
			//given
			Bank.Instance.CreateAccount();

			//when
			int result = Bank.Instance.GetNumbersOfAccounts();

			//then
			Assert.AreEqual(1, result);
		}


	}
}
