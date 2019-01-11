using System;
using BattleShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestPutShipOnTheBoard
    {
        [TestMethod]
        public void CParserCoordinateMethodShouldReturn1And2WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "a2";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
        }

        [TestMethod]
        public void CParserCoordinateMethodShouldReturn2And10WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "B10";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], 10);
        }
        [TestMethod]
        public void CParserCoordinateMethodShouldReturn4And5WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "D5";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 4);
            Assert.AreEqual(result[1], 5);
        }
    }
}