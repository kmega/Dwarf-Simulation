using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShip;

namespace Test
{
    [TestClass]
    public class GameOverTests
    {
        [TestMethod]
        public void ShouldReturnFalseWhenBoardHaveShips()
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

            bool result = GameOver.ShipsAreDestroyed(board,6);

            //Then
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void ShouldReturnTrueWhenAllShipsOnBoardAreDestroyed()
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

            bool result = GameOver.ShipsAreDestroyed(board,3);

            //Then
            Assert.AreEqual(true, result);


        }


    }
}
