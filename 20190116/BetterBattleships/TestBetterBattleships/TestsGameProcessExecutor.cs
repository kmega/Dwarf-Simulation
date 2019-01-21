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
            var notUsedBoardForTest = new BoardFactory().Create();
            int[] coords = { 1, 0 };

            //when
            GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(CellStatus.MISS, board[1, 0]);
        }

        [TestMethod]
        public void ShootsAtDeckFieldAndSetsItToHit()
        {
            //given
            var board = new BoardFactory().Create();
            var notUsedBoardForTest = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(CellStatus.HIT, board[1, 0]);
        }

        [TestMethod]
        public void ShootsAtFieldAndSetsItToHit()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(CellStatus.HIT, board[1, 0]);
        }

        [TestMethod]
        public void ShootsAtMissFieldAndReturnsFalse()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.MISS;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ShootsAtHitFieldAndReturnsFalse()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.HIT;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnFalseWhenShootButDoesntHitDeck()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.EMPTY;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnTrueWhenShootAndHitDeck()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            board[1, 0] = CellStatus.DECK;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ReturnsFalseWhenBoardHasEmptyCells()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };

            //when
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnsTrueWhenBoardHasDeckCells()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 1, 0 };


            //when
            board[1, 0] = CellStatus.DECK;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ReturnsFalseWhenBoardHasMissCells()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 2, 0 };

            //when
            board[1, 0] = CellStatus.MISS;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ReturnsFalseWhenBoardHasHitCells()
        {
            //given
            var notUsedBoardForTest = new BoardFactory().Create();
            var board = new BoardFactory().Create();
            var GPE = new GameProcessExecutor();
            int[] coords = { 2, 0 };


            //when
            board[1, 0] = CellStatus.HIT;
            var result = GPE.Shoot(board, coords, notUsedBoardForTest);

            //then
            Assert.AreEqual(false, result);
        }
    }
}
