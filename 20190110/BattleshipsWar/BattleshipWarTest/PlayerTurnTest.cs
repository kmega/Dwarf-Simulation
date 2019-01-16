using System;
using System.Collections.Generic;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class PlayerTurnTest
    {
        [TestMethod]
        public void ReturnFalseIfCoordinatesWrong()
        {
            //Given
            PlayerTurn pt = new PlayerTurn();
            int[] coordinatesshoot = new int[2] { 1, 11 };
            int[] coordinatesbuilt = new int[2] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[10, 10];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinatesbuilt, Direction.Left) };
            War war = new War();

            bool[] result = war.Shoot(coordinatesshoot, warmap, listofships);
            Assert.IsFalse(result[0]);


        }

        [TestMethod]
        public void ReturnTrueIfCoordinatesGood()
        {

            PlayerTurn pt = new PlayerTurn();
            int[] coordinatesshoot = new int[2] { 1, 2 };
            int[] coordinatesbuilt = new int[2] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[10, 10];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinatesbuilt, Direction.Left) };
            War war = new War();

            bool[] result = war.Shoot(coordinatesshoot, warmap, listofships);
            Assert.IsTrue(result[0]);


        }

        [TestMethod]
        public void ReturnFalseIfShootMiss()
        {
            PlayerTurn pt = new PlayerTurn();
            int[] coordinatesshoot = new int[2] { 0, 2 };
            int[] coordinatesbuilt = new int[2] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[1,3];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinatesbuilt, Direction.Left) };
            warmap[0, 2] = CellProperty.Empty;
            War war = new War();

            bool[] result = war.Shoot(coordinatesshoot, warmap, listofships);
            Assert.IsFalse(result[1]);



        }
        [TestMethod]
        public void ReturnTrueIfShootHit()
        {
            PlayerTurn pt = new PlayerTurn();
            int[] coordinatesshoot = new int[2] { 0, 1};
            int[] coordinatesbuilt = new int[2] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[1, 3];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinatesbuilt, Direction.Left) };
            warmap[0, 1] = CellProperty.Occupied;
            War war = new War();

            bool[] result = war.Shoot(coordinatesshoot, warmap, listofships);
            Assert.IsTrue(result[1]);


        }




    }
}
