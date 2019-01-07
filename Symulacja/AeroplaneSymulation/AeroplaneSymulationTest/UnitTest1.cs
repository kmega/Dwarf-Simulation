using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AeroplaneSymulation;
using System.Collections.Generic;

namespace AeroplaneSymulationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWieza1()
        {
            WiezaKontrolna wieza = new WiezaKontrolna();
            List<bool> test_places = new List<bool>();
            test_places.Add(true);

            Assert.AreEqual(wieza.check(test_places), true);
        }

        [TestMethod]
        public void TestWieza2()
        {
            WiezaKontrolna wieza = new WiezaKontrolna();
            List<bool> test_places = new List<bool>();
            test_places.Add(false);

            Assert.AreEqual(wieza.check(test_places), false);
        }

        [TestMethod]
        public void TestWieza3()
        {
            WiezaKontrolna wieza = new WiezaKontrolna();
            List<bool> test_places = new List<bool>();
            test_places.Add(false);
            test_places.Add(true);

            Assert.AreEqual(wieza.check(test_places), true);
        }

        [TestMethod]
        public void TestWieza4()
        {
            WiezaKontrolna wieza = new WiezaKontrolna();
            List<bool> test_change = new List<bool>();
            test_change.Add(true);
            test_change = wieza.change_to_full(test_change);

            Assert.AreEqual(test_change[0], false);
        }
    }
}
