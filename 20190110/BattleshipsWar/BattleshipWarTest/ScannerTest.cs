using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class ScannerTest
    {
        [TestMethod]
        public void IsCooridnatesInTable()
        {
            int[] coordinates = new int[] { 1, 1, };
            CellProperty[,] warmap = new CellProperty[2, 2];
            
            Scanner scanner = new Scanner();
            bool result = scanner.CheckCoordinatesCorrectness(coordinates, warmap);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCooridnatesOutOfTable()
        {
            int[] coordinates = new int[] { 1, 3, };
            CellProperty[,] warmap = new CellProperty[2, 2];

            Scanner scanner = new Scanner();
            bool result = scanner.CheckCoordinatesCorrectness(coordinates, warmap);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCellFree()
        {

            int[] coordinates = new int[] { 0, 0, };
            CellProperty[,] warmap =new CellProperty[1,1] { { CellProperty.Empty } };

            Scanner scaner = new Scanner();
            CellProperty result = scaner.CheckCellStatus(warmap, coordinates);

            Assert.AreEqual(CellProperty.Empty, result);

        }
        [TestMethod]
        public void IsShipDetected()
        {

            int[] coordinates = new int[] { 0, 0, };
            CellProperty[,] warmap = new CellProperty[1, 1] { { CellProperty.Occupied } };

            Scanner scaner = new Scanner();
            CellProperty result = scaner.CheckCellStatus(warmap, coordinates);

            Assert.AreEqual(CellProperty.Occupied, result);

        }




    }
}
