using System;
using FlySimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlightSimulatorTests
{
    [TestClass]
    public class FlySimulatorTests
    {
        [TestMethod]
        public void FirstPlaneShouldTakeFirstRunway()
        {
            //given
            FlightTower tower = new FlightTower();
            var plane = tower.airPlanes[0];
            var runways = tower.runways;
            //when
            tower.TakeThePlane(plane);


            //then
            Assert.AreEqual(false, runways[0].IsEmpty);

        }

        [TestMethod]
        public void FirstPlaneShouldTakeFirstRunwayOtherRunwayAreEmpty()
        {
            //given
            FlightTower tower = new FlightTower();
            var plane = tower.airPlanes[0];
            var runways = tower.runways;
            //when
            tower.TakeThePlane(plane);


            //then
            Assert.AreEqual(true, tower.runways[1].IsEmpty );

        }
    }
}
