using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Canteen;
using NUnit.Framework;
using System.Collections.Generic;

namespace SimulationTests.Canteen_Tests
{
    [TestFixture]
    internal class CanteenTests
    {
        private Canteen canteen = new Canteen();

        [Test]
        public void ShouldDecreaseFoodRationsByDwarfsConuntWhenDwarfListIsGiven()
        {
            //given
            canteen.FoodRations = 100;
            var numberOfDwarves = 3;
            //when
            canteen.GiveFoodRations(numberOfDwarves);
            //then
            Assert.AreEqual(97, canteen.FoodRations);
        }

        [TestCase(9, 39)]
        [TestCase(10, 10)]
        [TestCase(11, 11)]
        public void ShouldOrder30FoodRationsWhenAreLessThen10(int foodRations, int result)
        {
            //given
            canteen.FoodRations = foodRations;
            //when
            canteen.OrderFoodRations();
            //then
            Assert.AreEqual(result, canteen.FoodRations);
        }
    }
}