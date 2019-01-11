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

<<<<<<< HEAD:20190110/BattleshipsWar/BattleshipWarTest/ScannerTest.cs
            Scanner scanner = new Scanner();
            CellProperty result = scanner.CheckCellStatus(warmap, coordinates);
=======
            Scanner scaner = new Scanner();
            CellProperty result = scaner.CheckCellStatus(warmap, coordinates);
>>>>>>> 2bdacde221eefc4f1a857eaba617718839dfe94b:20190110/BattleshipsWar/BattleshipWarTest/ScannerTest.cs

            Assert.AreEqual(CellProperty.Empty, result);

        }
        [TestMethod]
        public void IsShipDetected()
        {

            int[] coordinates = new int[] { 0, 0, };
            CellProperty[,] warmap = new CellProperty[1, 1] { { CellProperty.Occupied } };

<<<<<<< HEAD:20190110/BattleshipsWar/BattleshipWarTest/ScannerTest.cs
            Scanner scanner = new Scanner();
            CellProperty result = scanner.CheckCellStatus(warmap, coordinates);
=======
            Scanner scaner = new Scanner();
            CellProperty result = scaner.CheckCellStatus(warmap, coordinates);
>>>>>>> 2bdacde221eefc4f1a857eaba617718839dfe94b:20190110/BattleshipsWar/BattleshipWarTest/ScannerTest.cs

            Assert.AreEqual(CellProperty.Occupied, result);

        }




    }
}
