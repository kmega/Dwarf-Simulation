using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samoloty;

namespace HappyPlaneTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnFalseheWhenThereIsNoFreeAirstrip()
        {
            List<Airstrip> airstrips = new List<Airstrip>();
            Airstrip airstrip = new Airstrip();
            airstrip.isFree = false;
            airstrips.Add(airstrip);
            bool expected = false;
            bool actual = new ControlTower(airstrips).isAnyFreeAirstrip();
            Assert.AreEqual(expected, actual);         
        }
        [TestMethod]
        public void ShouldReturnTrueWhenThereIsAnyFreeAirstrip()
        {
            List<Airstrip> airstrips = new List<Airstrip>();
            Airstrip airstrip = new Airstrip();
            airstrip.isFree = false;
            Airstrip airstrip2 = new Airstrip();
            airstrip2.isFree = true;
            airstrips.Add(airstrip);
            airstrips.Add(airstrip2);
            bool expected = true;
            bool actual = new ControlTower(airstrips).isAnyFreeAirstrip();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldDeleteCrashedPlaneFromPlaneList()
        {
            //given
            HappyPlaneSimulation simulation = new HappyPlaneSimulation();

            //act
           int actual = simulation.Simulation(50, 10);
            int expected = 7;

            Assert.AreEqual(expected, actual);
        }



    }
}
