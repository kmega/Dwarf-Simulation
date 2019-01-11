using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnEmptyBoard()
        {
            // For
            CellProperty[,] expectedResult = new CellProperty[10, 10];

            for (int i = 0; i < expectedResult.GetLength(i); i++)
            {
                for (int j = 0; j < expectedResult.GetLength(j); j++)
                {
                    expectedResult[i, j] = CellProperty.Empty;
                }
            }

            // Given
            CellProperty[,] result = StartGame.MakeBoard();

            // Assert
            for (int i = 0; i < expectedResult.GetLength(i); i++)
            {
                for (int j = 0; j < expectedResult.GetLength(j); j++)
                {
                    Assert.AreEqual(expectedResult[i, j], result[i, j]);
                }
            }
        }
    }
}
