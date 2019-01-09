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
        public void ShouldCreate50PlanesWithRandomFuelValue()
        {
            //given: 1 plane, 1 runway
            //bool expected = true;

            List<Airplane> airplanes = new List<Airplane>();
            for (int i = 1; i <= 10; i++)
            {
                airplanes.Add(
                    new Airplane() { Id = i, AmountOfFuel = 1 });
                airplanes.Add(
                    new Airplane() { Id = 10+i, AmountOfFuel = 3 });
                airplanes.Add(
                    new Airplane() { Id = 20+i, AmountOfFuel = 5 });
                airplanes.Add(
                    new Airplane() { Id = 30+i, AmountOfFuel = 7 });
                airplanes.Add(
                    new Airplane() { Id = 40+i, AmountOfFuel = 10 });
            }

            var planesWithFuel1 = airplanes.Where(x => x.AmountOfFuel == 1).Count();
            var planesWithFuel3 = airplanes.Where(x => x.AmountOfFuel == 3).Count();
            var planesWithFuel5 = airplanes.Where(x => x.AmountOfFuel == 5).Count();
            var planesWithFuel7 = airplanes.Where(x => x.AmountOfFuel == 7).Count();
            var planesWithFuel10 = airplanes.Where(x => x.AmountOfFuel == 10).Count();

            Assert.AreEqual(planesWithFuel1, 10, "There is 10 planes with amount of fuel = 1");
            Assert.AreEqual(planesWithFuel3, 10, "There is 10 planes with amount of fuel = 3");
            Assert.AreEqual(planesWithFuel5, 10, "There is 10 planes with amount of fuel = 5");
            Assert.AreEqual(planesWithFuel7, 10, "There is 10 planes with amount of fuel = 7");
            Assert.AreEqual(planesWithFuel10, 10, "There is 10 planes with amount of fuel = 10");

            //var airport = FakeDataFactory.GenerateAirport();
            ////when
            //bool actual = airport.TryLand(airplanes.First());
            ////then
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldLand1PlaneAfter3rdTurn()
        {
            //given: 1 plane, 1 runway
            List<Airplane> airplanes = new List<Airplane>
            {
                new Airplane() { Id = 1, FuelAtStart = 5, AmountOfFuel = 5 },
            };

            var airport = FakeDataFactory.GenerateAirport();
            //when
            var turnCounter = airport.SimulateLandingOfPlanesWithTurnsCounter(airplanes, 1000);

            //then
            Assert.IsTrue(turnCounter.Item1 > 3, "Plane has landed after 3 turn.");
        }

        [TestMethod]
        public void ShouldRefuelPlaneInTimeOfDifferenceBetweenStartAtStartAndCurrent()
        {
            //given: 1 plane, 1 runway
            List<Airplane> airplanes = new List<Airplane>
            {
                new Airplane() { Id = 1, FuelAtStart = 7, AmountOfFuel = 7 }
            };
            //List<Airplane> airplanes = new List<Airplane>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    airplanes.Add(
            //        new Airplane() { Id = i, FuelAtStart = 1, AmountOfFuel = 1 });
            //    airplanes.Add(
            //        new Airplane() { Id = 10 + i, FuelAtStart = 3, AmountOfFuel = 3 });
            //    airplanes.Add(
            //        new Airplane() { Id = 20 + i, FuelAtStart = 5, AmountOfFuel = 5 });
            //    airplanes.Add(
            //        new Airplane() { Id = 30 + i, FuelAtStart = 7, AmountOfFuel = 7 });
            //    airplanes.Add(
            //        new Airplane() { Id = 40 + i, FuelAtStart = 10, AmountOfFuel = 10 });
            //}

            var airport = FakeDataFactory.GenerateAirport();
            //when
            var turnCounter = airport.SimulateLandingOfPlanesWithTurnsCounter(airplanes, 1000);

            int expectedRefuelTime = 5;
            int resultRefuelTime = turnCounter.Item1;

            //var temp = 0;
            //then
            Assert.AreEqual(resultRefuelTime, expectedRefuelTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Ohh no! planes are crashing!")]
        public void Gets50PlanesAndWorks()
        {
            //given: 
            List<Airplane> airplanes = new List<Airplane>();
            for (int i = 1; i <= 10; i++)
            {
                //airplanes.Add(
                //    new Airplane() { Id = i, FuelAtStart = 1, AmountOfFuel = 1 });
                //airplanes.Add(
                //    new Airplane() { Id = 10 + i, FuelAtStart = 3, AmountOfFuel = 3 });
                //airplanes.Add(
                //    new Airplane() { Id = 20 + i, FuelAtStart = 5, AmountOfFuel = 5 });
                airplanes.Add(
                    new Airplane() { Id = 30 + i, FuelAtStart = 7, AmountOfFuel = 7 });
                airplanes.Add(
                    new Airplane() { Id = 40 + i, FuelAtStart = 10, AmountOfFuel = 10 });
            }

            var airport = FakeDataFactory.GenerateAirport();
            //when
            var turnCounter = airport.SimulateLandingOfPlanesWithTurnsCounter(airplanes, 1000);

            //int expectedRefuelTime = 5;
            int resultRefuelTime = turnCounter.Item1;

            
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

        [TestMethod]
        public void ShouldLand1Plane()
        {
            //given: 1 plane, 1 runway
            bool expected = true;

            List<Airplane> airplanes = new List<Airplane>
            {
                new Airplane() { Id = 1, AmountOfFuel = 200 }
            };

            var airport = FakeDataFactory.GenerateAirport();
            //when
            bool actual = airport.TryLand(airplanes.First());
            //then
            Assert.AreEqual(expected, actual);
        }
    }
}
