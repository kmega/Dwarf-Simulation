using System;
using System.Collections.Generic;
using System.Linq;
using AirportSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirportSimulationTests
{
    [TestClass]
    public class LandingTest
    {
        [TestMethod]
        public void ShouldLand1Plane()
        {
            //given: 1 plane, 1 runway
            bool expected = true;
            List<Airplane> airplanes = new List<Airplane>()
            { new Airplane(){ Id = 1, AmountOfFuel = 200 } };
            var airport = FakeDataFactory.GenerateAirport();
            //when
            bool actual = airport.TryLand(airplanes.First());
            //then
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Ohh no! 2 planes has crashed!")]
        public void ShouldCrash2Planes()
        {
            //given:
            List<Airplane> airplanes = FakeDataFactory.CreatePlanes();
            var airport = FakeDataFactory.GenerateAirport();
            //when
            airport.SimulateLandingOfPlanes(airplanes);
        }
    }
}
