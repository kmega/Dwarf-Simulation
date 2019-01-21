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
            List<KindOfShip> harbororder = new List<KindOfShip>();
            ShipInputParser parser = new ShipInputParser();
            string text = "emptyfile.txt";
            

            //When
            parser.MakeHarborOrder(text);

            //Then
            Assert.AreEqual(harbororder.Count, 0);

        }
        [TestMethod]
        public void ShouldReturnTwoShipsKindOfOne()
        {
            //Given
            ShipInputParser parser = new ShipInputParser();
            List<KindOfShip> harbororder = new List<KindOfShip>();
            string text = "1:2";

            //When
            parser.AddShip(harbororder,text);

            //Then
            Assert.AreEqual(harbororder[0], KindOfShip.One);
            Assert.AreEqual(harbororder[1], KindOfShip.One);
            Assert.AreEqual(harbororder.Count, 2);

        }
        [TestMethod]
        public void LastShipShouldBeKindFive()
        {
            //Given
            List<KindOfShip> harbororder = new List<KindOfShip>();
            ShipInputParser parser = new ShipInputParser();
            string text = "PlayerOneShipPlacement1.txt";

            //When          
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            //Then
            Assert.AreEqual(result[result.Count - 1], KindOfShip.Five);

        }
        [TestMethod]
        public void ShipsShouldContainsThreeShipsKindOf4()
        {
            //Given
            List<KindOfShip> harbororder = new List<KindOfShip>();
            ShipInputParser parser = new ShipInputParser();
            string text = "PlayerOneShipPlacement1.txt";

            //When
            List<KindOfShip> result = parser.MakeHarborOrder(text);

            var ShipsKindOfFour = result.Where(x => x == KindOfShip.Four).ToList();

            //Then
            Assert.AreEqual(ShipsKindOfFour.Count, 3);

        }

    }
        
}
