using System;
using System.Collections.Generic;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class PlayerTurnTest
    {
        //[TestMethod]
        //public void ReturnFalseIfCoordinatesWrong()
        //{
        //    //Given
        //    PlayerTurn pt = new PlayerTurn();
        //    int[] coordinatesshoot = new int[2] { 1, 8 };
        //    int[] coordinatesbuilt = new int[2] { 0, 1 };
        //    CellProperty[,] warmap = new CellProperty[1, 2];
        //    List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two,coordinatesbuilt, Direction.Left)};
        //    War war = new War();
            
        //   bool[] result = war.Shoot(coordinatesshoot, warmap, listofships);
        //    Assert.IsFalse(result[0]);


        //}

        [TestMethod]
        public void ReturnTrueIfCoordinatesGood()
        {


        }

        [TestMethod]
        public void ReturnFalseIfShootMiss()
        {


        }
        [TestMethod]
        public void ReturnTrueIfShootHit()
        {


        }




    }
}
