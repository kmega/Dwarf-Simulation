using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HappyPlanes.Tests
{
    [TestClass]
    public class FlySymulatorTests
    {
        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void ShouldThrowExceptionWhenFuelIsNegative()
        {
            //Given
            AirPlane Plane = new AirPlane("Samolot1");
            List<AirPlane> Planes = new List<AirPlane>();
            Planes.Add(Plane);
            Plane.Fuel = -1;

            //When
            FlySymulator symulator = new FlySymulator();
            symulator.CheckDoesAnyFuelIsNegative(Planes);


        }
    }
}
