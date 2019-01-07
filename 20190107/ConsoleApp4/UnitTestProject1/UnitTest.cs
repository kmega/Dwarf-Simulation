using Planes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ShouldReturnFalseWhenEverythingIsTrue()
        {
            bool[] landingPlaces = {
    true,
    true,
    true
   };

            Airport airport = new Airport();
            landingPlaces = airport.FindClearLandingPlace(landingPlaces);

            for (int i = 0; i < landingPlaces.Length; i++)
            {
                Assert.AreEqual(false, landingPlaces[i]);
            }
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAtLeastOneIsFalse()
        {
            bool[] landingPlaces = {
    true,
    false,
    true
   };

            Airport airport = new Airport();
            landingPlaces = airport.FindClearLandingPlace(landingPlaces);

            for (int i = 0; i < landingPlaces.Length; i++)
            {
                if (landingPlaces[i] == false)
                {
                    Assert.AreNotEqual(true, landingPlaces[i]);
                    break;
                }
            }
        }
    }
}