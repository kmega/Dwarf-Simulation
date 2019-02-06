using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Canteen;
using NUnit.Framework;
using System.Collections.Generic;

namespace SimulationTests.Canteen_Tests
{
    [TestFixture]
    internal class CanteenTests
    {
        private readonly List<Dwarf> dwarfs = new List<Dwarf>() { new Dwarf(), new Dwarf(), new Dwarf() };
        private Canteen canteen = new Canteen();

        [Test]
        public void ShouldDecreaseFoodRationsByDwarfsConuntWhenDwarfListIsGiven()
        {
            //given
            canteen.FoodRations = 100;
            //when
            canteen.GiveFoodRations(dwarfs);
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