using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaApp;

namespace TeaTests
{
    [TestClass]
    public class Task4Tests
    {
        private void TestMietaQuality(string expected, int temp, int time )
        {
            var fakeListGoodTeas = TeaData.fakeTeaList();
            string name = "Mięta";
            var result = TeaFactory.CheckTeaQuality(fakeListGoodTeas, name, temp, time);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturnPerfectTeaWhenTemp96AndTime300Sec()
        {
            TestMietaQuality("perfect", 96, 300);      
        }
        [TestMethod]
        public void ShouldReturnYuckyTea()
        {
            TestMietaQuality("yucky", 110, 300);
        }
        [TestMethod]
        public void ShouldReturnWeakTea()
        {
            TestMietaQuality("weak", 80, 300);
        }
        [TestMethod]
        public void ShouldReturnYuckyWhenIsWeakToo()
        {
            TestMietaQuality("yucky", 80, 350);
        }
    }
}
