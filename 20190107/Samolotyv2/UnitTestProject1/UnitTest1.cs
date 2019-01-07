using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Samoloty;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        AirPort airport = new AirPort();
        [TestMethod]
        public void isanyplaceontheairportwhenthereisplace()
        {
            List<int> Airplanes = new List<int> { 1, 2, 3 };
            List<int> AirStrip = new List<int> { 1, 2, 3 };
            bool expected = true;
            bool result = airport.IsLand(Airplanes, AirStrip);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void isanyplaceontheairportwhenthereis5stripsand6planes()
        {
            List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5 };
            bool expected = true;
            bool result = airport.IsLand(Airplanes, AirStrip);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void island13airplanewhenthereis10stripsand15planes()
        {
            List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int expected = 15;
            int result = airport.IsLand2(Airplanes, AirStrip);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void the50airplanesand10airstrips()
        {
            List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 };
            List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int expected = 170;
            int result = airport.IsLand3(Airplanes, AirStrip);
            Assert.AreEqual(expected, result);

        }

    }
}
