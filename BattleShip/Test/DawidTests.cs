using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace Test
{
    [TestClass]
    public class DawidTests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenBoardHaveShips()
        {
            //Given
            Board board = new Board();

            //When
            board.Fields[0, 1] = Field.F;
            board.Fields[0, 2] = Field.F;
            board.Fields[0, 3] = Field.F;

            board.Fields[4, 5] = Field.F;
            board.Fields[4, 6] = Field.F;
            board.Fields[4, 7] = Field.F;

            bool result = GameOver.ShipsAreDestroyed(board);

            //Then
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ShouldReturnTrueWhenAllShipsOnBoardAreDestroyed()
        {
            //Given
            Board board = new Board();

            //When
            board.Fields[4, 5] = Field.F;
            board.Fields[4, 6] = Field.F;
            board.Fields[4, 7] = Field.F;

            board.Fields[4, 5] = Field.H;
            board.Fields[4, 6] = Field.H;
            board.Fields[4, 7] = Field.H;

            bool result = GameOver.ShipsAreDestroyed(board);

            //Then
            Assert.AreEqual(true, result);


        }


    }
}
