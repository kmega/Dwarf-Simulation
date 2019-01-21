using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleshipsWar.Tools;

namespace BattleshipWarTest
{
    [TestClass]
    public class ConfigShipsParserTests
    {
        [TestMethod]
        public void ListShipsShouldBeEmptyWhenStringIsEmpty()
        {
            //Given
            ShipInputParser parser = new ShipInputParser();
            string text = "";
            

            //When
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            //Then
            Assert.AreEqual(result.Count, 0);

        }
        [TestMethod]
        public void ShouldReturnTwoShipsKindOfOne()
        {
            //Given
            ShipInputParser parser = new ShipInputParser();
            string text = "1:2";

            //When
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            //Then
            Assert.AreEqual(result[0], KindOfShip.One);
            Assert.AreEqual(result[1], KindOfShip.One);
            Assert.AreEqual(result.Count, 2);

        }
        [TestMethod]
        public void LastShipShouldBeKindFive()
        {
            //Given
            ShipInputParser parser = new ShipInputParser();
            string text = "1:2\n3:1\n5:2";

            //When          
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            //Then
            Assert.AreEqual(result[result.Count-1], KindOfShip.Five);

        }
        [TestMethod]
        public void ShipsShouldContainsThreeShipsKindOf4()
        {
            //Given
            ShipInputParser parser = new ShipInputParser();
            string text = "1:2\n3:1\n5:2\n4:3";

            //When
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            var ShipsKindOfFour = result.Where(x => x == KindOfShip.Four).ToList();

            //Then
            Assert.AreEqual(ShipsKindOfFour.Count, 3);

        }

    }
        
}
