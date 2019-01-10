using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class WarTest
    {
        [TestMethod]
        public void IsCooridnatesInTable()
        {
            string input = "A1";
            int[,] warmap = new int[2, 2];


            War war = new War();
           bool result=  war.CheckCoordinates(input, warmap);

            Assert.IsTrue(result);
        }
    }
}
