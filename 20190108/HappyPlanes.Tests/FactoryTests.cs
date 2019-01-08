using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HappyPlanes.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void ShouldReturnCountExistingPlanesEqualPlanesToCreate()
        {
            //Given
            List<AirPlane> ExistingPlanes = new List<AirPlane>();
            int planesToCreate = 50;
            int expected = 50;

            //When
            Factory Factory = new Factory();
            ExistingPlanes = Factory.MakeAirplanes(planesToCreate);
            int result = ExistingPlanes.Count;
            
            //Then
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ShouldReturnCountExistingBeltsEqualBeltsToCreate()
        {
            //Given
            List<LandBelts> ExistingBelts = new List<LandBelts>();
            int planesToCreate = 10;
            int expected = 10;

            //When
            Factory Factory = new Factory();
            ExistingBelts = Factory.MakeLandBelts(planesToCreate);
            int result = ExistingBelts.Count;

            //Then
            Assert.AreEqual(expected, result);

        }

    }
}
