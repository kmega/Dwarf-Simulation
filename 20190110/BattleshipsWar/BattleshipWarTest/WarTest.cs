using System;
using System.Collections.Generic;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class WarTest
    {
        [TestMethod]
        public void IsShipCanHit()
        {
            
            int[] coordinates = new int[] { 0, 0, };
            CellProperty[,] warmap = new CellProperty[1, 1] { { CellProperty.Occupied } };
            List<Ship> listofships = new List<Ship>();

            War war = new War();
            war.Shoot(coordinates, warmap,listofships);


            Assert.IsTrue(warmap[0, 0] == CellProperty.Hit);
        }


        [TestMethod]
        public void IsShipCanBeDamage()
        {

            int[] coordinates = new int[] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[1, 2];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinates, Direction.Left) };
            warmap[0, 0] = CellProperty.Occupied;
            warmap[0, 1] = CellProperty.Occupied;


            War war = new War();
            war.Shoot(coordinates, warmap, listofships);


            Assert.IsTrue(warmap[0, 1] == CellProperty.Hit);
            Assert.IsTrue(warmap[0, 0] == CellProperty.Occupied);
        }
        [TestMethod]
        public void IsShipCanBeDestroy()
        {

            int[] coordinates = new int[] { 0, 1 };
            CellProperty[,] warmap = new CellProperty[1, 2];
            List<Ship> listofships = new List<Ship>() { new Ship(KindOfShip.Two, coordinates, Direction.Left) };
            warmap[0, 0] = CellProperty.Hit;
            warmap[0, 1] = CellProperty.Occupied;


            War war = new War();
            war.Shoot(coordinates, warmap, listofships);


           Assert.IsTrue(warmap[0, 0] == CellProperty.Destroyed);
            Assert.IsTrue(warmap[0, 1] == CellProperty.Destroyed);
        }



    }


}
