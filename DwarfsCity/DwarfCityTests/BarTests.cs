using DwarfsCity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DwarfsCity.DwarfContener;

namespace DwarfCityTests
{
    [TestClass]
    public class BarTests
    {
        Bar bar = new Bar();
        List<Dwarf> DwarfsList = new List<Dwarf> { null,null,null,null,null, null, null, null, null, null, };           
       
        [TestMethod]
        public void ShouldReturnSupplyAfterDinner()
        {
            int Supply = bar.SupplyofFood;
            bar.GiveAFoodToDwarfs(Supply, DwarfsList);
            int expectedsupply = 190;
            int resultsupply = bar.SupplyofFood;
            Assert.AreEqual(expectedsupply, resultsupply);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ShouldReturnExceptionWhenFoodIsOver()
        {
            bar.SupplyofFood = 5;
            int Supply = bar.SupplyofFood;
            bar.GiveAFoodToDwarfs(Supply, DwarfsList);
            int expectedsupply = -5;
            int resultsupply = bar.SupplyofFood;
            Assert.AreEqual(expectedsupply, resultsupply);    
        }
        [TestMethod]
        public void ShouldAdd30SupplyWhenSupplyAreLessThan10()
        {        
            bar.SupplyofFood = 11;
            int Supply = bar.SupplyofFood;           
            bar.GiveAFoodToDwarfs(Supply, DwarfsList);
            int expectedsupply = 31;
            int resultsupply = bar.SupplyofFood;  
            Assert.AreEqual(expectedsupply, resultsupply);
        }
    }
}
