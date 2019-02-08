using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DwarfsCity.DwarfContener;
using DwarfsCity;
using DwarfsCity.ShopContener;
using DwarfsCity.DwarfContener.DwarfEquipment;

namespace DwarfCityTests
{
    [TestClass]
    public class ShopTests
    {
        [TestMethod]
        public void ShouldGiveReportWhenDwarfVisitShop()
        {
            // given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Dwarf dwarfFather = new Dwarf() { Backpack = new Backpack()};
            dwarfFather.Attribute = DwarfsCity.DwarfContener.Type.Father;
            Dwarf dwarfSingle = new Dwarf() { Backpack = new Backpack() };
            dwarfSingle.Attribute = DwarfsCity.DwarfContener.Type.Father;
            dwarfs.Add(dwarfFather);
            dwarfs.Add(dwarfSingle);
            Shop shop = new Shop();

            // when
            string expectectedDwarFatherReport = @"Dwarf bought Alcohol and paid 0";
            string expectectedDwarSingleReport = @"Dwarf bought Alcohol and paid 0";
            shop.PerformShopping(dwarfs);
            var Raports = shop.Reports;

            //then
            string actualDwarfFatherReport = Raports[0];
            string actualDwarfSingleReport = Raports[1];
            Assert.AreEqual(expectectedDwarFatherReport, actualDwarfFatherReport);
            Assert.AreEqual(expectectedDwarSingleReport, actualDwarfSingleReport);






        }


        [TestMethod]
        public void ShouldDwarfPayHalfMoneyWhenDwarfTypeIsFatherOrSingle()
        {
            //given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Dwarf dwarfFather = new Dwarf();
            dwarfFather.Attribute = DwarfsCity.DwarfContener.Type.Father;
            dwarfFather.Backpack.Money = 1000;
            Dwarf dwarfSingle = new Dwarf();
            dwarfSingle.Attribute = DwarfsCity.DwarfContener.Type.Father;
            dwarfSingle.Backpack.Money = 1000;
            dwarfs.Add(dwarfFather);
            dwarfs.Add(dwarfSingle);
            Shop shop = new Shop();

            decimal expectedFatherMoney = dwarfFather.Backpack.Money / 2;
            decimal expectedSingleMoney = dwarfSingle.Backpack.Money / 2;
            //when
            shop.PerformShopping(dwarfs);

            // then
            decimal actualFatherMoney = dwarfFather.Backpack.Money;
            decimal actualSingleMoney = dwarfSingle.Backpack.Money;
            Assert.AreEqual(expectedFatherMoney, actualFatherMoney);
            Assert.AreEqual(expectedSingleMoney, actualSingleMoney);

        }
    }
}
