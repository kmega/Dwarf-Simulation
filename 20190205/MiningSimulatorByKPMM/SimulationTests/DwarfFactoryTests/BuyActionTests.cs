using System;
using System.Collections.Generic;
using System.Text;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using NUnit.Framework;

namespace SimulationTests.DwarfFactoryTests
{
    class BuyActionTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ShouldBuyProductFoodWith5Quantity()
        {
            //given
            IDwarf dwarf = DwarfFactory.Create(E_DwarfType.Dwarf_Father);
            (dwarf as Dwarf).BankAccount.ReceivedMoney(10.0m);
            //when
            var product = dwarf.Buy();
            //then
            Assert.IsTrue(product.Quantity == 5.0m);
            Assert.IsTrue(product.ProductType == E_ProductsType.Food);
        }
    }
}
