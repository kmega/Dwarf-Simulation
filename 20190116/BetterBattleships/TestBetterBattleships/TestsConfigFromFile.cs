using System;
using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsConfigFromFile
    {
        [TestMethod]
        public void temp1()
        {
            var temp = new AvailableShips();

            var temp2 = temp.GetShipsFromConfigFile();
        }
    }
}
