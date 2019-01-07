using AirFlightSimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HappyPlanesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldRetrunFreeLandingLane()
        {
            //given
            Planes plane = new Planes(1, 200);

            //expected
            LandingLane expectedLane = new LandingLane("asd123", true, 0);

            //then
            LandingLane lane = new ControlTower().TryGetLandigPermission(plane);

            Assert.AreEqual(expectedLane.lanePositionEncrypted, lane.lanePositionEncrypted);
        }
    }
}
