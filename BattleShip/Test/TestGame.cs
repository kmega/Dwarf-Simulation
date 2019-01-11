using System;
using BattleShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestMethod1()
        {
            Game game = new Game();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            string coordinatesPlayer1 = "a1";
            string coordinatesPlayer2 = "a1";
            game.TryHitShip(player1, player2, coordinatesPlayer1, coordinatesPlayer2);
            int counter = 0;
            if (player1.Opponent_Board.Fields[0, 0] == Field.F)
            {
                counter++;
            }
            Assert.AreEqual(counter, 1);
        }
    }
}
