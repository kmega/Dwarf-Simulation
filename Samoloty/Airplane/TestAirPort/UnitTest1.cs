using System;
using Airplane;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAirPort
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsPlaneLand()
        {
            ControlTower ct = new ControlTower();
            ListPlanes listofplanes = new ListPlanes();
            listofplanes.AddPlane(4);

            ct.PlaneLand(listofplanes.planelist);

            Assert.IsTrue(listofplanes.planelist[0].landed);

        }
        [TestMethod]
        public void IsPlaneCrashed()
        {
            ControlTower ct = new ControlTower();
            ListPlanes listofplanes = new ListPlanes();
            listofplanes.AddPlane(0);
            listofplanes.DecreaseFuel();
            listofplanes.CheckFuel();

            

            Assert.IsTrue(listofplanes.planelist[0].isCrashed);

        }

        [TestMethod]
        public void IsPlaneWithLowerFuelLandedFirst()
        {
            ControlTower ct = new ControlTower();
            ListPlanes listofplanes = new ListPlanes();
            listofplanes.AddPlane(4);
            listofplanes.AddPlane(3);
            listofplanes.AddPlane(2);
           
            listofplanes.CheckLowestFuel(listofplanes);

            ct.PlaneLand(listofplanes.planelist);

            Assert.IsTrue(listofplanes.planelist[0].landed);
            Assert.AreEqual(5, listofplanes.planelist[0].FuelLeft);

        }

        [TestMethod]
        public void IsWorkFor5Planes()
        {
            ControlTower ct = new ControlTower();
            ListPlanes listofplanes = new ListPlanes();

            for (int i = 0; i < 5; i++)
            {
                listofplanes.AddPlane(1);
                ct.PlaneLand(listofplanes.planelist);
                listofplanes.DecreaseFuel();
                listofplanes.CheckFuel();
                listofplanes.CheckLowestFuel();
                ct.TrackOccupied();
                
            }




          

        }





    }
}
