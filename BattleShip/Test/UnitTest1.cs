using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void T01TestInicjalizePalyer1()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        {
            Player Player1 = new Player(1);

            Assert.AreEqual(Player1.Id, 1);
        }

        //We can have problems with this test, because when we create more
        //Board we will need more ships in game
        [TestMethod]
        public void T02TestHowMuchIsShipsGetResult3()
        {
            Player Player1 = new Player(1);

            int counter = 0;
            for (int i = 0; i < Player1.ships.Count; i++)
            {
                counter++;
            }

            Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void T03TestHowAreLenghtShipNumber1GetResult1()
        {
            Player Player1 = new Player(1);

            Assert.AreEqual(Player1.ships[0].Lenght, 1);
        }

        [TestMethod]
        public void T04TestHowAreLenghtShipNumber2GetResult2()
        {
            Player Player1 = new Player(1);

            Assert.AreEqual(Player1.ships[1].Lenght, 2);
        }

        [TestMethod]
        public void T05TestHowAreLenghtShipNumber3GetResult3()
        {
            Player Player1 = new Player(1);

            Assert.AreEqual(Player1.ships[2].Lenght, 3);
        }

        [TestMethod]
        public void T06TestWait()
        {
            
        }
    }
}
