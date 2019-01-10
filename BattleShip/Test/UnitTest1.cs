using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        {
            Player Player1 = new Player(1);

            Assert.AreEqual(Player1.Id, 1);
            Assert.AreEqual(Player1.ships[2].Lenght, 3);
        }
    }
}
