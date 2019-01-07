using NUnit.Framework;
using HappyPlanes;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
       
        [Test]
        public void OnePlaneOneFreeRunWay_TryLand_True()
        {
            //given
            Planes plane_1 = new Planes(1);
            ControlTower tower = new ControlTower();
            Runway runway_1 = new Runway(1);
            Simulation simulate = new Simulation();

            Runway runway_2 = new Runway(1);

            List<Planes> listOfPlanes = new List<Planes>();
            List<Runway> listOfRunways = new List<Runway>();
            //act
            simulate.Start(plane_1,runway_1);

            //expected
            int result = plane_1.GetPlaneState();
            bool result_2 = runway_1.AllRunwaysIdAndState[1];
            Assert.AreEqual(5, result);
            Assert.AreEqual(false, result);
        }
    }
}