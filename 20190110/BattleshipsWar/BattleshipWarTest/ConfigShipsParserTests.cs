using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BattleshipWarTest
{
    [TestClass]
    class ConfigShipsParserTests
    {
        [TestMethod]
        public void ListShipsShouldBeEmptyWhenStringIsEmpty()
        {
            //Given
            string text = "";
            

            //When
            List<KindOfShip> result = ShipInputParser.costam(text);

            //Then
            Assert.AreEqual(result.Count, 0);

        }
        [TestMethod]
        public void ShouldReturnTwoShipsKindOfOne()
        {
            //Given
            string text = "1:2";

            //When
            List<KindOfShip> result = ShipInputParser.costam(text, listastatkow);

            //Then
            Assert.AreEqual(result[0], KindOfShip.One);
            Assert.AreEqual(result[1], KindOfShip.One);
            Assert.AreEqual(result.Count, 2);

        }
        [TestMethod]
        public void LastShipShouldBeKindFive()
        {
            //Given
            string text = "1:2\n3:1\n5:2";

            //When
            List<KindOfShip> result = ShipInputParser.costam(text, listastatkow);

            //Then
            Assert.AreEqual(result[result.Count-1], KindOfShip.Five);

        }
        [TestMethod]
        public void ShipsShouldContainsThreeShipsKindOf4()
        {
            //Given
            string text = "1:2\n3:1\n5:2\n4:3";

            //When
            List<KindOfShip> result = ShipInputParser.costam(text, listastatkow);

            var ShipsKindOfFour = result.Where(x => x == KindOfShip.Four).ToList();

            //Then
            Assert.AreEqual(ShipsKindOfFour.Count, 3);

        }

    }
        
}
