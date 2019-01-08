using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamolotyWziuum;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        ControlTower ct = new ControlTower();
        Plane plane = new Plane(1);

        [TestMethod]
        public void CheckingDoesAnyRunWayIsFree()
        {
            int expected = 1;

            int result = ct.CheckForFreeLandingRunWay();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RunwayNumber1ShouldBeFalse()
        {
            plane.TryLand(ct);

            bool result = ct.allRunWays[0].available;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlaneShouldntBeInTheAir()
        {
            plane.TryLand(ct);

            bool result = plane.planeInAir;

            Assert.IsFalse(result);
        }
    }
}
