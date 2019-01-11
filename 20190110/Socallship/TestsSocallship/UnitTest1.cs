using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socallship;
using System;
using System.Linq;

namespace TestsSocallship
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatesOnePlayerWithBoardGame()
        {
            //given
            string name = "XYZ";
            //when
            Player player1 = new Player(name);
            //then
            Assert.AreEqual(name, player1.GetName());
        }

        [TestMethod]
        public void ShootsAtOtherPlayerBoardAndSetsNewStatus()
        {
            //given
            Player player1 = new Player("QWE");
            Player player2 = new Player("ASD");

            //when
            player1.ShotAtPlayersBoard(player2, new int[] { 0, 0 });

            //then
            Assert.AreEqual(BoardCellType.MISS, player2.GetBoardCellStatus(player2.GetPlayerBoard(), 0,0));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ThrowExceptionWhenShootsAtBoardCellTypeMiss()
        {
            //given
            Player player1 = new Player("QWE");
            Player player2 = new Player("ASD");
            player2.SetBoardCellStatus(0, 0, BoardCellType.MISS);

            //when
            player1.ShotAtPlayersBoard(player2, new int[] { 0, 0 });

            //then
        }
    }
}
