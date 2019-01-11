using System;
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

            War war = new War();
            war.Shoot(coordinates, warmap);


            Assert.IsTrue(warmap[0, 0] == CellProperty.Hit);
        }
    }


}
