using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samoloty;

namespace PlanesTestsUnit
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ShouldReturnFalseWhenAllHaveMoreFuelThan2()
        {
            List<Plane> planes = new List<Plane>();
            int planesNumber = 3;

            Simulation simulation = new Simulation(planesNumber);

            for (int i = 0; i < planesNumber - 1; i++)
            {
                planes.Add(new Plane(i, 5));
            }
            

            Assert.AreEqual(false, simulation.CheckIfCanLand(planes));
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAtLeastOneHaveFewerThan2()
        {
            List<Plane> planes = new List<Plane>();
            int planesNumber = 3;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 5));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 5));

            Assert.AreEqual(true, simulation.CheckIfCanLand(planes));
        }

        [TestMethod]
        public void OneShouldLand()
        {
            List<Plane> planes = new List<Plane>();
            int planesNumber = 3;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 5));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 5));

            planes = simulation.HasLanded(planes);

            Assert.AreEqual(false, planes[0].hasLanded);
            Assert.AreEqual(true, planes[1].hasLanded);
            Assert.AreEqual(false, planes[2].hasLanded);
        }

        [TestMethod]
        public void OnlyOneShouldLandWhenTwoCanLand()
        {
            List<Plane> planes = new List<Plane>();
            int planesNumber = 3;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 5));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 1));

            planes = simulation.HasLanded(planes);

            Assert.AreEqual(false, planes[0].hasLanded);
            Assert.AreEqual(true, planes[1].hasLanded);
            Assert.AreEqual(false, planes[2].hasLanded);
        }

        [TestMethod]
        public void ShouldSubstractFuelByOneAndDeletePlanesWithNoFuel()
        {
            List<Plane> planes = new List<Plane>();
            List<Plane> planes2 = new List<Plane>();
            int planesNumber = 3;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 5));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 5));

            planes2.Add(new Plane(0, 4));
            planes2.Add(new Plane(2, 4));
            planes = simulation.SubstractFuel(planes);

            CollectionAssert.AreEqual(planes2, planes);
        }


        [TestMethod]
        public void ShouldAddFuelAndDeletePlanesWithMoreFuelThan5()
        {
            List<Plane> planes = new List<Plane>();
            List<Plane> planes2 = new List<Plane>();
            List<Plane> planes3 = new List<Plane>();
            int planesNumber = 3;
            bool landingPad = false;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 4));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 5));

            planes[2].hasLanded = true;
            planes[2].landingPadNumber = 1;

            planes2.Add(new Plane(0, 4));
            planes2.Add(new Plane(1, 1));
            planes3 = simulation.LoadFuel(planes, landingPad);

            CollectionAssert.AreEqual(planes2, planes3);
        }

        [TestMethod]
        public void ShouldAddFuelAndDeletePlanesWitsafdsadfsahMoreFuelThan5()
        {
            List<Plane> planes = new List<Plane>();
            List<Plane> planes2 = new List<Plane>();
            List<Plane> planes3 = new List<Plane>();
            int planesNumber = 3;
            bool landingPad = false;

            Simulation simulation = new Simulation(planesNumber);

            planes.Add(new Plane(0, 4));
            planes.Add(new Plane(1, 1));
            planes.Add(new Plane(2, 5));

            planes[2].hasLanded = true;
            planes[2].landingPadNumber = 1;

            planes[1].hasLanded = true;
            planes[1].landingPadNumber = 2;

            planes2.Add(new Plane(0, 4));
            planes2.Add(new Plane(1, 2));

            planes2[1].hasLanded = true;
            planes2[1].landingPadNumber = 2;

            planes3 = simulation.LoadFuel(planes, landingPad);

            CollectionAssert.AreEqual(planes2, planes3);
        }
    }
}
