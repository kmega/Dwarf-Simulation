using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class StartGameTests
    {
        [TestMethod]
        public void ShouldReturnEmptyBoardWhenCoordinatesAreWrong()
        {
            // For
            StartGame game = new StartGame();
            CellProperty[,] board = new CellProperty[10, 10];
            string coordinates = "z1";
            string direction = "up";

            // Given
            CellProperty[,] expectedBoard = game.PlaceShipOnBoard(board, coordinates, direction);

            // Assert
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.IsTrue(board[i, j] == expectedBoard[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShouldReturnEmptyBoardWhenDirectionIsWrong()
        {
            // For
            CellProperty[,] expectedBoard = new CellProperty[10, 10];

            CellProperty[,] board = new CellProperty[10, 10];
            string coordinates = "a1";
            string direction = "below";

            // Given
            StartGame game = new StartGame();
            expectedBoard = game.PlaceShipOnBoard(board, coordinates, direction);

            // Assert
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.IsTrue(board[i, j] == expectedBoard[i, j]);
                }
            }
        }

        [TestMethod]
        public void ShouldReturnModifiedBoardWhenInputIsValid()
        {
            // For
            CellProperty[,] expectedBoard = new CellProperty[10, 10];

            CellProperty[,] board = new CellProperty[10, 10];
            string coordinates = "a1";
            string direction = "right";

            // Given
            StartGame game = new StartGame();
            game.PlaceShipOnBoard(board, coordinates, direction);

            // Assert
            for (int i = 0; i < 6; i++)
            {
                Assert.IsTrue(board[0, i] != expectedBoard[0, i]);
            }
        }
    }
}
