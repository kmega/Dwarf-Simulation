using System;
using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsBattleshipGameExecutor
    {
        [TestMethod]
        public void ReturnPlayer1AsWinnerBecauseHeHasDeckCellsLeft()
        {
            //given
            var BGE = new BattleshipGameExecutor();
            IPlayer p1 = new PlayerFactory().ProducePlayer();
            IPlayer p2 = new PlayerFactory().ProducePlayer();

            //when
            (p1.GetBoard())[1, 1] = CellStatus.DECK;
            var result = BGE.ProcessGameAndReturnWinner(p1, p2, false);
            //then
            Assert.AreEqual(p1, result);
        }

        [TestMethod]
        public void ReturnPlayer2AsWinnerBecauseHeHasDeckCellsLeft()
        {
            //given
            var BGE = new BattleshipGameExecutor();
            IPlayer p1 = new PlayerFactory().ProducePlayer("p1");
            IPlayer p2 = new PlayerFactory().ProducePlayer("p2");

            //when
            (p2.GetBoard())[1, 1] = CellStatus.DECK;
            var result = BGE.ProcessGameAndReturnWinner(p1, p2, shootBool: false);
            //then
            Assert.AreEqual(p2, result);
        }
    }
}
