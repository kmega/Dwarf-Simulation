using System;
using BattleShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestArena
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player player1 = new Player(1);
            Player player2 = new Player(2);

            Arena arena = new Arena();
            player2.Player_Board.Fields[0, 0] = Field.S;

            arena.Fight(player1, player2, "A1");
            Assert.AreEqual(player1.ShootBoard.Fields[0, 0], Field.H);
            Assert.AreEqual(player2.Player_Board.Fields[0, 0], Field.H);

        }
    }
}
