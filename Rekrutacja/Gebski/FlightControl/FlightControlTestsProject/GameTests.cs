using FlightControlProject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FlightControlTestsProject
{
    internal class GameTests
    {
        [Test]
        public void ShouldRemoveFuelFromAirplanesWhenAreInAir()
        {
            //given
            var airplanes = new List<Airplane>() { new Airplane(5) };
            var airstrips = new List<Airstrip>() { new Airstrip() };
            ControlTower ct = new ControlTower(airplanes, airstrips);
            //when
            ct.RemoveFuelFromAirplanesInAir();
            //then
            Assert.AreEqual(airplanes.First().Fuel, 4);
        }

        [Test]
        public void ShouldPlanesTakeOffWhenAreFullOfFuel()
        {
            //given
            var airplanes = new List<Airplane>() { new Airplane(5) { IsInAir = false, } };
            var airstrips = new List<Airstrip>() { new Airstrip() { IsFree = false} };
            ControlTower ct = new ControlTower(airplanes, airstrips);
            //when
            ct.PlanesOnGroundWithFullOfFuelTakeOff();
            //then
            Assert.AreEqual(airplanes.First().IsInAir, true);
        }
    }
}