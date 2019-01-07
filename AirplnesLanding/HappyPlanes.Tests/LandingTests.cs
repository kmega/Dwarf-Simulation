using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HappyPlanes.Tests
{
    [TestClass]
    public class LandingTests
    {
        [TestMethod]
        public void ShouldReturnLandinSuccesTrueWhenFreeSpacesExist()
        {
            //Given
            LandBelts Belt = new LandBelts("Pas1");
            AirPlane Plane = new AirPlane("Samolot1");
            bool expected = true;

            //When
            FlightTower Tower = new FlightTower();
            Plane.PermissionToLanding = Tower.GivePermissionToLanding(Belt);

            //Then
            Assert.AreEqual(expected, Plane.PermissionToLanding);

        }
    }
}
