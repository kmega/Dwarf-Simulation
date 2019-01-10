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
            listofplanes.AddPlane(0);

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
            listofplanes.AddPlane(2);
            listofplanes.AddPlane(1);
            listofplanes.AddPlane(0);
           
            listofplanes.CheckLowestFuel();

            ct.PlaneLand(listofplanes.planelist);

            Assert.IsTrue(listofplanes.planelist[0].landed);
            Assert.AreEqual(1, listofplanes.planelist[0].FuelLeft);

        }

        




          

        





    }
}
