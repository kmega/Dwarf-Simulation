using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateChopTests
{
    [TestClass]
    public class KarateChopTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Chopper chopper = new Chopper();

            int[] blankArr = new int[0];

            Assert.AreEqual(-1, chop(3, blankArr));
            Assert.AreEqual(-1, chop(3, new int[1]));
            Assert.AreEqual(0, chop(1, new int[1]));

            Assert.AreEqual(0, chop(1, new int[1, 3, 5]));
            Assert.AreEqual(1, chop(3, new int[1, 3, 5]));
            Assert.AreEqual(2, chop(5, new int[1, 3, 5]));
            Assert.AreEqual(-1, chop(0, new int[1, 3, 5]));
            Assert.AreEqual(-1, chop(2, new int[1, 3, 5]));
            Assert.AreEqual(-1, chop(4, new int[1, 3, 5]));
            Assert.AreEqual(-1, chop(6, new int[1, 3, 5]));

            Assert.AreEqual(0, chop(1, new int[1, 3, 5, 7]));
            Assert.AreEqual(1, chop(3, new int[1, 3, 5, 7]));
            Assert.AreEqual(2, chop(5, new int[1, 3, 5, 7]));
            Assert.AreEqual(3, chop(7, new int[1, 3, 5, 7]));
            Assert.AreEqual(-1, chop(0, new int[1, 3, 5, 7]));
            Assert.AreEqual(-1, chop(2, new int[1, 3, 5, 7]));
            Assert.AreEqual(-1, chop(4, new int[1, 3, 5, 7]));
            Assert.AreEqual(-1, chop(6, new int[1, 3, 5, 7]));
            Assert.AreEqual(-1, chop(8, new int[1, 3, 5, 7]));
        }
    }
}
