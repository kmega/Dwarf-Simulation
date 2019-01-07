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

        [TestMethod]
        public void CheckingDoewAnyRunWayIsFree()
        {
            int expected = 1;
            int result = ct.CheckForFreeLandingRunWay();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultipleRunways()
        {

        }
    }
}
