using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace Test
{
    [TestClass]
    public class GameOverTests
    {
        [TestMethod]
        public void ShouldReturnTrueWhenBoardHaveShips()
        {
            //Given
            Board board = new Board();

            //When
            board.Fields[0, 1] = Field.S;
            board.Fields[0, 2] = Field.S;
            board.Fields[0, 3] = Field.S;

            board.Fields[4, 5] = Field.S;
            board.Fields[4, 6] = Field.S;
            board.Fields[4, 7] = Field.S;

            bool result = GameOver.ShipsAreDestroyed(board);

            //Then
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenAllShipsOnBoardAreDestroyed()
        {
            //Given
            Board board = new Board();

            //When
            board.Fields[4, 5] = Field.S;
            board.Fields[4, 6] = Field.S;
            board.Fields[4, 7] = Field.S;

            board.Fields[4, 5] = Field.H;
            board.Fields[4, 6] = Field.H;
            board.Fields[4, 7] = Field.H;

            bool result = GameOver.ShipsAreDestroyed(board);

            //Then
            Assert.AreEqual(false, result);


        }


    }
}
