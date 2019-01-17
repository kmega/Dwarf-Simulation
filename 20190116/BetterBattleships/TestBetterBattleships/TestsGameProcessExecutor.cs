using System;
using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsGameProcessExecutor
    {
        [TestMethod]
        public void ShootsAtEmptyFieldAndSetsItToMiss()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(CellStatus.MISS, board[1, 0]);
        }

        [TestMethod]
        public void ShootsAtDeckFieldAndSetsItToHit()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(CellStatus.HIT, board[1, 0]);
        }

        [TestMethod]
        public void ShootsAtFieldAndSetsItToHit()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(CellStatus.HIT, board[1, 0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Miss on miss")]
        public void ShootsAtMissFieldAndThrowsException()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.MISS;
            GPE.Shoot(board, coords);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Hit on hit")]
        public void ShootsAtHitFieldAndThrowsException()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.HIT;
            GPE.Shoot(board, coords);
        }

        [TestMethod]
        public void ReturnFalseWhenShootButDoesntHitDeck()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.EMPTY;
            var result = GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnTrueWhenShootAndHitDeck()
        {
            //given
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            var result = GPE.Shoot(board, coords);

            //then
            Assert.AreEqual(true, result);
        }
    }
}
