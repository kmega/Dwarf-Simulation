using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DwarfsCity.DwarfContener;
using DwarfsCity;

namespace DwarfCityTests
{
    [TestClass]
    public class ShopTests
    {
        [TestMethod]
        public void ShouldDwarfPayHalfMoneyWhenDwarfTypeIsFatherOrSingle()
        {
            //given
            List<Dwarf> dwarfs = new List<Dwarf>();
            Dwarf dwarfFather = new Dwarf();
            dwarfFather.Attrybute = DwarfsCity.DwarfContener.Type.Father;
            dwarfFather.Backpack.Moneys = 1000;
            Dwarf dwarfSingle = new Dwarf();
            dwarfSingle.Attrybute = DwarfsCity.DwarfContener.Type.Father;
            dwarfSingle.Backpack.Moneys = 1000;
            dwarfs.Add(dwarfFather);
            dwarfs.Add(dwarfSingle);
            Shop shop = new Shop();

            decimal expectedFatherMoney = dwarfFather.Backpack.Moneys / 2;
            decimal expectedSingleMoney = dwarfSingle.Backpack.Moneys / 2;
            //when
            shop.PerformShopping(dwarfs);

            // then
            decimal actualFatherMoney = dwarfFather.Backpack.Moneys;
            decimal actualSingleMoney = dwarfSingle.Backpack.Moneys;
            Assert.AreEqual(expectedFatherMoney, actualFatherMoney);
            Assert.AreEqual(expectedSingleMoney, actualSingleMoney);

        }
    }
}
