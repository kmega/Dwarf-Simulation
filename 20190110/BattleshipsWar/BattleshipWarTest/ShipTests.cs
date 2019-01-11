using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void ListCoordsFromShipCountShouldBe6ForShipKindOfSix()
        {
            //Given
            InputParser parser = new InputParser();
            int[] coords = parser.ChangeCordsToIndexes("I6");
            int expected = 6;

            //When
            Ship ship = new Ship(KindOfShip.Six, coords, Direction.Up);
            int result = ship.Coords.Count;

            //Then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ListCoordsFromShipCountShouldBe4ForShipKindOfFour()
        {
            //Given
            InputParser parser = new InputParser();
            int[] coords = parser.ChangeCordsToIndexes("I6");
            int expected = 6;

            //When
            Ship ship = new Ship(KindOfShip.Six, coords, Direction.Up);
            int result = ship.Coords.Count;

            //Then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void LastCoordsShipKindSixShouldBe4and6ForStartCoordsJ6()
        {
            //Given
            InputParser parser = new InputParser();
            int[] coords = parser.ChangeCordsToIndexes("J6");
            int[] expected = new[] { 4, 5 };

            //When
            Ship ship = new Ship(KindOfShip.Six, coords, Direction.Up);
            int[] result = ship.Coords[5];

            //Then
            CollectionAssert.AreEqual(expected, result);
;        }
    }
}
