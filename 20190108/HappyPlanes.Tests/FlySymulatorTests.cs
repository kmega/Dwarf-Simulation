using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HappyPlanes.Tests
{
    [TestClass]
    public class FlySymulatorTests
    {
        
        [TestMethod]
        public void ShouldAddPlaneToDestroyedsPlaneListWhenFuelIsNegative()
        {
            //Given
            AirPlane Plane = new AirPlane("Samolot1",-1);
            List<AirPlane> Planes = new List<AirPlane>();
            Planes.Add(Plane);

            //When
            FlySymulator symulator = new FlySymulator();
            symulator.CheckDoesAnyFuelIsNegative(Planes);
            List<AirPlane> destroyedPlanes = symulator.stats.DestroyedPlanes;
            CollectionAssert.Contains(destroyedPlanes, Plane);

        }
    }
}
