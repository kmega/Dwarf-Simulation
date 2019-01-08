using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HappyPlanes.Tests
{
    [TestClass]
    public class LandingTests
    {
        [TestMethod]
        public void ShouldReturnLandingSuccesTrueWhenFreeSpacesExist()
        {
            //Given
            LandBelts Belt = new LandBelts("Pas1");
            AirPlane Plane = new AirPlane("Samolot1",7);
            bool expected = true;

            //When
            FlightTower Tower = new FlightTower();
            Tower.FreeLandBelts.Add(Belt);
            Plane.OnTheAir = Tower.GivePermissionToLanding();

            //Then
            Assert.AreEqual(expected, Plane.OnTheAir);

        }

        [TestMethod]
        public void ShouldReturnFreeLandWhenIs5Tour()
        {
            //Given
            LandBelts Belt = new LandBelts("Pas1");
            FlightTower Tower = new FlightTower();
            Tower.OccupiedLandBelts.Add(Belt);

            bool expected = true;
            //When


            Tower.SetFreeOneBelt();
            bool result = Tower.FreeLandBelts.Count > 0;

            //Then
            Assert.AreEqual(expected, result);

        }
    }
}
