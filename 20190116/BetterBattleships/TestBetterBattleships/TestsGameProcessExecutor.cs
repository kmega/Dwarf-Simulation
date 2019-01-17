using System;
using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsGameProcessExecutor
    {
        [TestMethod]
        public void temp()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 1 };
            //when
            GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(CellStatus.HIT, board[1, 1]);
        }
    }
}
