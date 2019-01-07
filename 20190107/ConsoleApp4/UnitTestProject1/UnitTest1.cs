using System;
using ConsoleApp4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnFalseWhenEverythingIsOccupied()
        {
            bool[] landingPlaces = { true, true, true };
            Airport airport = new Airport();
            bool result = airport.FindClearLandingPlace(landingPlaces);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAtLeastOneIsAvailable()
        {
            bool[] landingPlaces = { true, false, false };
            Airport airport = new Airport();
            bool result = airport.FindClearLandingPlace(landingPlaces);
            Assert.AreEqual(true, result);
        }
    }
}
