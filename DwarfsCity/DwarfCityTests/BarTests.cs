using DwarfsCity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DwarfCityTests
{
    [TestClass]
    public class BarTests
    {
        Bar bar = new Bar();
        [TestMethod]
        public void ShouldReturnSupplyAfterDinner()
        {
            int Supply = bar.SupplyofFood;
            bar.GiveAFoodToDwarfs(Supply);
            //List<DwarfsCity.DwarfContener.Dwarf> Dwarfs = List
                //return new DwarfsCity.DwarfContener.Dwarf();
            int expectedsupply = 190;
            int resultsupply = bar.SupplyofFood;
            Assert.AreEqual(expectedsupply, resultsupply);

        }
        [TestMethod]
        public void ShouldReturnExceptionWhenFoodIsOver()
        {
        }
        [TestMethod]
        public void ShouldAdd30SupplyWhenSupplyAreLessThan10()
        {        
            bar.SupplyofFood = 11;
            int Supply = bar.SupplyofFood;           
            bar.GiveAFoodToDwarfs(Supply);
            int expectedsupply = 31;
            int resultsupply = bar.SupplyofFood;  
            Assert.AreEqual(expectedsupply, resultsupply);

        }

    }
}
