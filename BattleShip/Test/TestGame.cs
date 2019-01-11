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
            string coordinates = "a1";
            game.HitShip(player1, player2, coordinates);
        }
    }
}
